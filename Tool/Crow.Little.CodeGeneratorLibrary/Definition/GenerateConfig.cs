namespace Crow.Little.CodeGeneratorLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class CodeGenerateSetting
    {
        public string Name { get; set; }
        public DBSetting DB { get; set; }
        public SolutionSetting Solution { get; set; }

        public string Path
        {
            get
            {
                return Solution == null ? String.Empty : Solution.SlnPath;
            }
        }

        public void ToXml(XmlDocument doc, XmlNode rootNode)
        {
            XmlElement setting = doc.CreateElement("setting");
            rootNode.AppendChild(setting);

            XmlAttribute name = doc.CreateAttribute("name");
            name.Value = Name;
            setting.Attributes.Append(name);

            setting.AppendChild(DB.ToXml(doc));
            setting.AppendChild(Solution.ToXml(doc));
        }
        public static CodeGenerateSetting FromXml(string xmlContent)
        {
            CodeGenerateSetting setting = null;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlContent);
                setting = new CodeGenerateSetting();

                setting.Name = SettingAssistant.FindAttributeContent(doc, "/setting", "name");
                setting.DB = DBSetting.FromXml(SettingAssistant.FindOuterContent(doc, "/setting/db"));
                setting.Solution = SolutionSetting.FromXml(SettingAssistant.FindOuterContent(doc, "/setting/solution"));
            }
            finally
            {
                doc = null;
            }
            return setting;
        }
    }
    public class DBSetting
    {
        public string Provider { get; set; }
        public string Server { get; set; }
        public string DB { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement setting = doc.CreateElement("db");

            XmlAttribute provider = doc.CreateAttribute("provider");
            provider.Value = Provider;
            setting.Attributes.Append(provider);

            XmlAttribute server = doc.CreateAttribute("server");
            server.Value = Server;
            setting.Attributes.Append(server);

            XmlAttribute db = doc.CreateAttribute("db");
            db.Value = DB;
            setting.Attributes.Append(db);

            XmlAttribute uid = doc.CreateAttribute("uid");
            uid.Value = User;
            setting.Attributes.Append(uid);

            XmlAttribute pwd = doc.CreateAttribute("pwd");
            pwd.Value = Password;
            setting.Attributes.Append(pwd);

            return setting;
        }
        public static DBSetting FromXml(string xmlContent)
        {
            DBSetting setting = null;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlContent);
                setting = new DBSetting();

                setting.Provider = SettingAssistant.FindAttributeContent(doc, "/db", "provider");
                setting.Server = SettingAssistant.FindAttributeContent(doc, "/db", "server");
                setting.DB = SettingAssistant.FindAttributeContent(doc, "/db", "db");
                setting.User = SettingAssistant.FindAttributeContent(doc, "/db", "uid");
                setting.Password = SettingAssistant.FindAttributeContent(doc, "/db", "pwd");
            }
            finally
            {
                doc = null;
            }
            return setting;
        }
    }
    public class SolutionSetting
    {
        public string SlnPath { get; set; }
        public ModelSetting Model { get; set; }
        public DALSetting DAL { get; set; }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement setting = doc.CreateElement("solution");

            XmlAttribute path = doc.CreateAttribute("path");
            path.Value = SlnPath;
            setting.Attributes.Append(path);

            setting.AppendChild(Model.ToXml(doc));
            setting.AppendChild(DAL.ToXml(doc));

            return setting;
        }
        public static SolutionSetting FromXml(string xmlContent)
        {
            SolutionSetting setting = null;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlContent);
                setting = new SolutionSetting();

                setting.SlnPath = SettingAssistant.FindAttributeContent(doc, "/solution", "path");
                setting.Model = ModelSetting.FromXml(SettingAssistant.FindOuterContent(doc, "/solution/model"));
                setting.DAL = DALSetting.FromXml(SettingAssistant.FindOuterContent(doc, "/solution/dal"));
            }
            finally
            {
                doc = null;
            }
            return setting;
        }
    }
    public class ModelSetting
    {
        public string Path { get; set; }
        public string NameSpace { get; set; }
        public string ModelPrefix { get; set; }
        public string ModelPostfix { get; set; }
        public MemberNameCollisionSolution ModelCollision { get; set; }
        public string PropertyPrefix { get; set; }
        public string PropertyPostfix { get; set; }
        public MemberNameCollisionSolution PropertyCollision { get; set; }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement setting = doc.CreateElement("model");

            XmlAttribute path = doc.CreateAttribute("path");
            path.Value = Path;
            setting.Attributes.Append(path);

            XmlAttribute ns = doc.CreateAttribute("ns");
            ns.Value = NameSpace;
            setting.Attributes.Append(ns);

            XmlAttribute mPrefix = doc.CreateAttribute("mPrefix");
            mPrefix.Value = ModelPrefix;
            setting.Attributes.Append(mPrefix);

            XmlAttribute mPostfix = doc.CreateAttribute("mPostfix");
            mPostfix.Value = ModelPostfix;
            setting.Attributes.Append(mPostfix);

            XmlAttribute mCollision = doc.CreateAttribute("mCollision");
            mCollision.Value = ((int)ModelCollision).ToString();
            setting.Attributes.Append(mCollision);

            XmlAttribute pPrefix = doc.CreateAttribute("pPrefix");
            pPrefix.Value = PropertyPrefix;
            setting.Attributes.Append(pPrefix);

            XmlAttribute pPostfix = doc.CreateAttribute("pPostfix");
            pPostfix.Value = PropertyPostfix;
            setting.Attributes.Append(pPostfix);

            XmlAttribute pCollision = doc.CreateAttribute("pCollision");
            pCollision.Value = ((int)PropertyCollision).ToString();
            setting.Attributes.Append(pCollision);

            return setting;
        }
        public static ModelSetting FromXml(string xmlContent)
        {
            ModelSetting setting = null;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlContent);
                setting = new ModelSetting();

                setting.Path = SettingAssistant.FindAttributeContent(doc, "/model", "path");
                setting.NameSpace = SettingAssistant.FindAttributeContent(doc, "/model", "ns");
                setting.ModelPrefix = SettingAssistant.FindAttributeContent(doc, "/model", "mPrefix");
                setting.ModelPostfix = SettingAssistant.FindAttributeContent(doc, "/model", "mPostfix");
                setting.ModelCollision = SettingAssistant.TryToGetCollision(SettingAssistant.FindAttributeContent(doc, "/model", "mCollision"));
                setting.PropertyPrefix = SettingAssistant.FindAttributeContent(doc, "/model", "pPrefix");
                setting.PropertyPostfix = SettingAssistant.FindAttributeContent(doc, "/model", "pPostfix");
                setting.PropertyCollision = SettingAssistant.TryToGetCollision(SettingAssistant.FindAttributeContent(doc, "/model", "pCollision"));
            }
            finally
            {
                doc = null;
            }
            return setting;
        }
    }
    public class DALSetting
    {
        public string Path { get; set; }
        public string NameSpace { get; set; }
        public string DALPrefix { get; set; }
        public string DALPostfix { get; set; }
        public MemberNameCollisionSolution DALCollision { get; set; }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement setting = doc.CreateElement("dal");

            XmlAttribute path = doc.CreateAttribute("path");
            path.Value = Path;
            setting.Attributes.Append(path);

            XmlAttribute ns = doc.CreateAttribute("ns");
            ns.Value = NameSpace;
            setting.Attributes.Append(ns);

            XmlAttribute prefix = doc.CreateAttribute("prefix");
            prefix.Value = DALPrefix;
            setting.Attributes.Append(prefix);

            XmlAttribute postfix = doc.CreateAttribute("postfix");
            postfix.Value = DALPostfix;
            setting.Attributes.Append(postfix);

            XmlAttribute collision = doc.CreateAttribute("collision");
            collision.Value = ((int)DALCollision).ToString();
            setting.Attributes.Append(collision);

            return setting;
        }
        public static DALSetting FromXml(string xmlContent)
        {
            DALSetting setting = null;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlContent);
                setting = new DALSetting();

                setting.Path = SettingAssistant.FindAttributeContent(doc, "/dal", "path");
                setting.NameSpace = SettingAssistant.FindAttributeContent(doc, "/dal", "ns");
                setting.DALPrefix = SettingAssistant.FindAttributeContent(doc, "/dal", "prefix");
                setting.DALPostfix = SettingAssistant.FindAttributeContent(doc, "/dal", "postfix");
                setting.DALCollision = SettingAssistant.TryToGetCollision(SettingAssistant.FindAttributeContent(doc, "/dal", "collision"));
            }
            finally
            {
                doc = null;
            }
            return setting;
        }
    }
    /// <summary>
    /// 成员名称与关键字冲突的解决方案
    /// </summary>
    public enum MemberNameCollisionSolution
    {
        /// <summary>
        /// 首字母大写
        /// </summary>
        ConvertFirstWordToUpper = 0,
        /// <summary>
        /// 添加下划线做前缀
        /// </summary>
        AddUnderLinePrefix = 1,
    }

    internal class SettingAssistant
    {
        internal static string FindOuterContent(XmlDocument doc, string xpath)
        {
            string content = String.Empty;
            XmlNode node = doc.SelectSingleNode(xpath);
            content = node == null ? String.Empty : node.OuterXml;
            return content;
        }

        internal static string FindAttributeContent(XmlDocument doc, string xpath, string attributeName)
        {
            string attrContent = String.Empty;
            XmlNode node = doc.SelectSingleNode(xpath);
            XmlAttribute attribute = node == null ? null : node.Attributes[attributeName];
            attrContent = attribute == null ? String.Empty : attribute.Value;
            return attrContent;
        }

        internal static MemberNameCollisionSolution TryToGetCollision(string attributeValue)
        {
            int collision = 0;
            int.TryParse(attributeValue, out collision);
            if (Enum.GetValues(typeof(MemberNameCollisionSolution)).Cast<int>().Contains(collision))
                return (MemberNameCollisionSolution)collision;
            return MemberNameCollisionSolution.ConvertFirstWordToUpper;
        }
    }
}
