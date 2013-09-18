using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Crow.Little.CommonControl
{
    /// <summary>
    /// 继承自TabControl的带有关闭按钮的通用TabControl
    /// 通过控件重绘实现
    /// </summary>
    public partial class CloseableTabControl : TabControl
    {
        #region Field
        const int CLOSE_SIZE = 12;
        #endregion
        #region Property
        #endregion
        #region Constructor
        public CloseableTabControl()
            : base()
        {
            //清空控件
            base.TabPages.Clear();
            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            base.DrawMode = TabDrawMode.OwnerDrawFixed;
            base.Padding = new System.Drawing.Point(base.Padding.X + CLOSE_SIZE, base.Padding.Y);
            base.DrawItem += new DrawItemEventHandler(CommonTabControl_DrawItem);
            base.MouseDown += new MouseEventHandler(CommonTabControl_MouseDown);
        }
        #endregion
        #region Event
        public event EventHandler<CancelEventArgs> TabPageClosing;
        #endregion
        #region Method
        public void AddTabPage(CloseableTabPage tabPage)
        {
            this.TabPages.Add(tabPage);
        }
        private void CommonTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Rectangle myTabRect = this.GetTabRect(e.Index);

                //先添加TabPage属性
                StringFormat tabFormat = new StringFormat() { Alignment = StringAlignment.Center };
                Rectangle tabRect = new Rectangle(myTabRect.X + base.Margin.Left, myTabRect.Y + base.Margin.Top, myTabRect.Width - CLOSE_SIZE, myTabRect.Height);
                e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, tabRect, tabFormat);

                //如果tabpage支持关闭，将继续绘制关闭按钮
                if (AllowShowCloseButton(e.Index))
                {
                    //再画一个矩形框
                    using (Pen p = new Pen(Color.Black, 1.2F))
                    {
                        myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + base.Margin.Right), base.Margin.Top);
                        myTabRect.Width = CLOSE_SIZE;
                        myTabRect.Height = CLOSE_SIZE;
                        e.Graphics.DrawRectangle(p, myTabRect);
                    }

                    //填充矩形框
                    Color recColor = Color.Transparent;
                    using (Brush b = new SolidBrush(recColor))
                    {
                        e.Graphics.FillRectangle(b, myTabRect);
                    }

                    //画关闭符号
                    using (Pen objpen = new Pen(Color.Black, 1.2F))
                    {
                        //"\"线
                        Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                        Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                        e.Graphics.DrawLine(objpen, p1, p2);

                        //"/"线
                        Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                        Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                        e.Graphics.DrawLine(objpen, p3, p4);
                    }
                }

                e.Graphics.Dispose();
            }
            catch
            {
                throw;
            }
        }
        private void CommonTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!AllowShowCloseButton(this.SelectedIndex))
                    return;

                int x = e.X, y = e.Y;

                //计算关闭区域   
                Rectangle myTabRect = this.GetTabRect(this.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right
                 && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isClose == true)
                {
                    CancelEventArgs canceling = new CancelEventArgs(false);
                    if (TabPageClosing != null)
                    {
                        TabPageClosing(this.TabPages[this.SelectedIndex], canceling);
                    }

                    if (!canceling.Cancel)
                    {
                        this.TabPages.Remove(this.SelectedTab);
                    }
                }
            }
        }
        private bool AllowShowCloseButton(int tabPageIndex)
        {
            TabPage tpg = this.TabPages[tabPageIndex];
            if (tpg is CloseableTabPage && ((CloseableTabPage)tpg).ShowCloseButton)
                return true;
            else
                return false;
        }
        #endregion
    }
}
