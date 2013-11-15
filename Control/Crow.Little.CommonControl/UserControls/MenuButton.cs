using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crow.Little.Common;

namespace Crow.Little.CommonControl
{
    public partial class MenuButton : UserControl
    {
        #region Field
        private bool isActive = false;
        private EventHandler callAction;
        #endregion

        #region Property
        #endregion

        #region Constructor
        public MenuButton()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        #endregion

        #region Method
        #region Conrol Event Handler
        private void pbxImage_Click(object sender, EventArgs e)
        {
            callAction(this, EventArgs.Empty);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            callAction(this, EventArgs.Empty);
        }
        #endregion

        #region Custom Method
        public void AddMenuButton(string title, Image img, EventHandler eventAction)
        {
            AddMenuButton(title, img, eventAction, true);
        }

        public void AddMenuButton(string title, Image img, EventHandler eventAction, bool isDefault)
        {
            callAction = eventAction;
            this.AddImage(img);
            this.AddTitle(title);

            if (isDefault)
            {
                eventAction(this, EventArgs.Empty);
            }
        }

        public void ActiveTitle()
        {
            this.lblTitle.Font = new Font(this.lblTitle.Font.FontFamily, this.lblTitle.Font.Size, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;

            this.isActive = true;
        }

        public void UnActiveTitle()
        {
            this.lblTitle.Font = new Font(this.lblTitle.Font.FontFamily, this.lblTitle.Font.Size, FontStyle.Regular);
            this.lblTitle.ForeColor = Color.Black;

            this.isActive = false;
        }

        private void AddImage(Image img)
        {
            this.pbxImage.Image = img;
            this.pbxImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void AddTitle(string title)
        {
            this.lblTitle.Text = title;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            bool beSeleted = false;
            this.lblTitle.Tag = beSeleted;
        }

        private void imgButton_MouseHover(object sender, EventArgs e)
        {
            this.StressTitle(this.lblTitle);
        }

        private void imgButton_MouseLeave(object sender, EventArgs e)
        {
            this.UnStressTitle(this.lblTitle);
        }

        private void lblTitle_MouseHover(object sender, EventArgs e)
        {
            this.StressTitle(this.lblTitle);
        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            this.UnStressTitle(this.lblTitle);
        }

        private void StressTitle(Label lblTitle)
        {
            if (!isActive)
            {
                lblTitle.Font = new Font(lblTitle.Font.FontFamily, lblTitle.Font.Size, FontStyle.Bold);
                lblTitle.ForeColor = Color.Black;
            }
        }

        private void UnStressTitle(Label lblTitle)
        {
            if (!isActive)
            {
                lblTitle.Font = new Font(lblTitle.Font.FontFamily, lblTitle.Font.Size, FontStyle.Regular);
                lblTitle.ForeColor = Color.Black;
            }
        }
        #endregion
        #endregion
    }
}
