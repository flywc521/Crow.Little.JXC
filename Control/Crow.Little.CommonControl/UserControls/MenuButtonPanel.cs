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
    public partial class MenuButtonPanel : UserControl
    {
        #region Field
        #endregion

        #region Property
        #endregion

        #region Constructor
        public MenuButtonPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        public event EventHandler MenuButtonAdded;
        #endregion

        #region Method
        public void AddImgButton(string title, Image img, EventHandler eventAction)
        {
            AddImgButton(title, img, eventAction, true);
        }

        public void AddImgButton(string title, Image img, EventHandler eventAction, bool isDefault)
        {
            AddMenuButton(title, img, eventAction, isDefault);
        }

        public void ActiveTitle(object sender)
        {
            foreach (Control ctrl in this.flpMenuButton.Controls)
            {
                if (ctrl is MenuButton)
                {
                    ((MenuButton)ctrl).UnActiveTitle();
                }
            }

            MenuButton menuButton = sender as MenuButton;
            if (menuButton != null)
            {
                menuButton.ActiveTitle();
            }
        }

        private MenuButton AddMenuButton(string title, Image img, EventHandler eventAction, bool isDefault)
        {
            MenuButton menuButton = new MenuButton();
            menuButton.AddMenuButton(title, img, eventAction, isDefault);

            menuButton.Width = this.Width - menuButton.Margin.Left - menuButton.Margin.Right;
            menuButton.Height = 48 + 23 + menuButton.Margin.Top + menuButton.Margin.Bottom;
            this.flpMenuButton.Controls.Add(menuButton);

            return menuButton;
        }

        private void OnMenuButtonAdded(MenuButton menuButton)
        {
            if (MenuButtonAdded != null)
            {
                MenuButtonAdded(menuButton, EventArgs.Empty);
            }
        }
        #endregion
    }
}
