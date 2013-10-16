using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.CodeGenerator.dbConfig
{
    public class CtrlDbConfig : UserControl
    {
        protected DbSettingItem dbItem = new DbSettingItem();
        public virtual DbSettingItem DBSetting { get { return dbItem; } }
        public CtrlDbConfig()
        {
        }
        public CtrlDbConfig(int provider)
        {
            dbItem.Provider = provider.ToString();
        }
        public virtual void InitDbSetting(DbSettingItem dbSetting)
        {
        }
    }
}
