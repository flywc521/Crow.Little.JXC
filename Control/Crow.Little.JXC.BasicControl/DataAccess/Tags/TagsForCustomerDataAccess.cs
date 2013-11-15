namespace Crow.Little.JXC.BasicControl.DataAccess
{
	using Crow.Little.Common;
	using Crow.Little.DBHelper;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.Common;
	using System.Drawing;
	using System.Xml;
	using Crow.Little.JXC.BasicControl.Model;

	public partial class TagsForCustomerDataAccess
	{
		#region Field
		#endregion
		#region Property
		#endregion
		#region Constructor
		#endregion
		#region Event
		#endregion
		#region Method
		public static List<TagsForCustomer> LoadAll()
		{
			List<TagsForCustomer> itemList = new List<TagsForCustomer>();

			string strSql = @"
SELECT [CustomerID],[TagID]
FROM [TagsForCustomer]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					TagsForCustomer model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static TagsForCustomer Load(string CustomerID, long TagID)
		{
			TagsForCustomer model = null;
			string strSql = @"
SELECT [CustomerID],[TagID]
FROM [TagsForCustomer]
WHERE [CustomerID] = @CustomerID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", CustomerID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", TagID, DbType.Int64));

			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql, CommandType.Text, paramList.ToArray()))
			{
				while (reader.Read())
				{
					model = ConvertToModel(reader);
					break;
				}
			}

			return model;
		}

		public static bool Delete(string CustomerID, long TagID)
		{
			string strSql = @"DELETE FROM [TagsForCustomer] WHERE [CustomerID] = @CustomerID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", CustomerID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", TagID, DbType.Int64));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(TagsForCustomer model)
		{
			string strSql = @"
UPDATE [TagsForCustomer]
SET 
WHERE [CustomerID] = @CustomerID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", model.CustomerID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", model.TagID, DbType.Int64));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertTagsForCustomer(TagsForCustomer model)
		{
			string strSql = @"
INSERT INTO [TagsForCustomer] ([CustomerID], [TagID])
VALUES (@CustomerID, @TagID)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", model.CustomerID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", model.TagID, DbType.Int64));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static TagsForCustomer ConvertToModel(DbDataReader reader)
		{
			TagsForCustomer model = new TagsForCustomer();
			model.CustomerID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.TagID = reader.IsDBNull(1) ? (long)0 : reader.GetInt64(1);
			return model;
		}

		#endregion
	}
}
