using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.CodeGenerator
{
    public partial class FormTableFilter : Form
    {
        #region Field
        #endregion
        #region Property
        public List<string> SelectedTables { get; set; }
        public List<string> AllTables { get; set; }
        #endregion
        #region Constructor
        public FormTableFilter()
        {
            InitializeComponent();
        }
        #endregion
        #region Event
        #endregion
        #region Method
        private void FormTableFilter_Load(object sender, EventArgs e)
        {
            foreach (string tableName in AllTables)
            {
                this.lbxTableList.Items.Add(tableName);
            }
        }
        private void btnGenerateAll_Click(object sender, EventArgs e)
        {
            this.lbxTableList4Generate.Items.Clear();
            foreach (var tableName in this.lbxTableList.Items)
            {
                this.lbxTableList4Generate.Items.Add(tableName);
            }
            this.lbxTableList.Items.Clear();
        }
        private void btnGenerateSelected_Click(object sender, EventArgs e)
        {
            for (int i = this.lbxTableList.SelectedItems.Count - 1; i >= 0; i--)
            {
                this.lbxTableList4Generate.Items.Add(this.lbxTableList.SelectedItems[i]);
                this.lbxTableList.Items.Remove(this.lbxTableList.SelectedItems[i]);
            }
        }
        private void btnUnGenerateSelected_Click(object sender, EventArgs e)
        {
            for (int i = this.lbxTableList4Generate.SelectedItems.Count - 1; i >= 0; i--)
            {
                this.lbxTableList.Items.Add(this.lbxTableList4Generate.SelectedItems[i]);
                this.lbxTableList4Generate.Items.Remove(this.lbxTableList4Generate.SelectedItems[i]);
            }
        }
        private void btnUnGenerateAll_Click(object sender, EventArgs e)
        {
            this.lbxTableList.Items.Clear();
            foreach (var tableName in this.lbxTableList.Items)
            {
                this.lbxTableList.Items.Add(tableName);
            }
            this.lbxTableList4Generate.Items.Clear();
        }
        private void lbxTableList_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbxTableList.SelectedItem != null)
            {
                this.lbxTableList4Generate.Items.Add(this.lbxTableList.SelectedItem);
                this.lbxTableList.Items.Remove(this.lbxTableList.SelectedItem);
            }
        }
        private void lbxTableList4Generate_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbxTableList4Generate.SelectedItem != null)
            {
                this.lbxTableList.Items.Add(this.lbxTableList4Generate.SelectedItem);
                this.lbxTableList4Generate.Items.Remove(this.lbxTableList4Generate.SelectedItem);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedTables = new List<string>();
            foreach (var tableName in this.lbxTableList4Generate.Items)
            {
                SelectedTables.Add(tableName.ToString());
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
