namespace Crow.Little.CodeGenerator
{
    using Crow.Little.CodeGeneratorLibrary;
    using Crow.Little.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class FormExistFilesFilter : Form
    {
        #region Field
        #endregion
        #region Property
        public List<Tuple<string, string, string>> ConveredTableNameList
        {
            get;
            set;
        }
        #endregion
        #region Constructor
        public FormExistFilesFilter()
        {
            InitializeComponent();
        }
        #endregion
        #region Event
        #endregion
        #region Method
        private void FormExistFilesFilter_Load(object sender, EventArgs e)
        {
            this.dgvExistFilesFilter.AutoGenerateColumns = false;
            this.colTableName.DataPropertyName = "TableName";
            this.colModel.DataPropertyName = "ModelPath";
            this.colDALName.DataPropertyName = "DalPath";

            this.dgvExistFilesFilter.DataSource = (from Tuple<string, string, string> item in ConveredTableNameList
                                                   select new
                                                   {
                                                       TableName = item.Item1,
                                                       ModelPath = item.Item2,
                                                       DalPath = item.Item3,
                                                   }).ToList();
        }
        private void llbSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvExistFilesFilter.Rows)
            {
                if (row.Index >= 0 && row.Cells["colCheck"] != null)
                {
                    row.Cells["colCheck"].Value = true;
                }
            }
        }
        private void llbSelectNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvExistFilesFilter.Rows)
            {
                if (row.Index >= 0 && row.Cells["colCheck"] != null)
                {
                    row.Cells["colCheck"].Value = false;
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ConveredTableNameList = new List<Tuple<string, string, string>>();
            foreach (DataGridViewRow row in this.dgvExistFilesFilter.Rows)
            {
                if (row.Index >= 0 && row.Cells["colCheck"] != null && row.Cells["colCheck"].Value != null && (bool)row.Cells["colCheck"].Value)
                {
                    Tuple<string, string, string> item = new Tuple<string, string, string>(row.Cells["colTableName"].Value.ToString(), row.Cells["colModel"].Value.ToString(), row.Cells["colDALName"].Value.ToString());
                    ConveredTableNameList.Add(item);
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
