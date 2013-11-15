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

	public partial class TagsForCommodityDataAccess
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
		public static List<TagsForCommodity> LoadAll()
		{
			List<TagsForCommodity> itemList = new List<TagsForCommodity>();

			string strSql = @"
SELECT [CommodityID],[TagID]
FROM [TagsForCommodity]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					TagsForCommodity model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static TagsForCommodity Load(string CommodityID, long TagID)
		{
			TagsForCommodity model = null;
			string strSql = @"
SELECT [CommodityID],[TagID]
FROM [TagsForCommodity]
WHERE [CommodityID] = @CommodityID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", CommodityID, DbType.String));
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

		public static bool Delete(string CommodityID, long TagID)
		{
			string strSql = @"DELETE FROM [TagsForCommodity] WHERE [CommodityID] = @CommodityID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", TagID, DbType.Int64));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(TagsForCommodity model)
		{
			string strSql = @"
UPDATE [TagsForCommodity]
SET 
WHERE [CommodityID] = @CommodityID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", model.TagID, DbType.Int64));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertTagsForCommodity(TagsForCommodity model)
		{
			string strSql = @"
INSERT INTO [TagsForCommodity] ([CommodityID], [TagID])
VALUES (@CommodityID, @TagID)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagID", model.TagID, DbType.Int64));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static TagsForCommodity ConvertToModel(DbDataReader reader)
		{
			TagsForCommodity model = new TagsForCommodity();
			model.CommodityID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.TagID = reader.IsDBNull(1) ? (long)0 : reader.GetInt64(1);
			return model;
		}

		#endregion
	}
}
