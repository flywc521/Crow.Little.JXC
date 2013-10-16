using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.CodeGenerator.dbConfig
{
    public partial class CtrlSqlServerConfig : CtrlDbConfig
    {
        public override DbSettingItem DBSetting
        {
            get { throw new NotImplementedException(); }
        }

        public CtrlSqlServerConfig(int provider)
            : base(provider)
        {
            InitializeComponent();
        }
    }
}
