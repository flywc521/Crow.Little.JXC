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

	public partial class TagsForSupplierDataAccess
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
		public static List<TagsForSupplier> LoadAll()
		{
			List<TagsForSupplier> itemList = new List<TagsForSupplier>();

			string strSql = @"
SELECT [SupplierID],[TagID]
FROM [TagsForSupplier]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					TagsForSupplier model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static TagsForSupplier Load(string SupplierID, long TagID)
		{
			TagsForSupplier model = null;
			string strSql = @"
SELECT [SupplierID],[TagID]
FROM [TagsForSupplier]
WHERE [SupplierID] = @SupplierID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierID", SupplierID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@TagID", TagID, DbType.Int64));

			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql, CommandType.Text, paramList.ToArray()))
			{
				while (reader.Read())
				{
					model = ConvertToModel(reader);
					break;
				}
			}

			return model;
		}

		public static bool Delete(string SupplierID, long TagID)
		{
			string strSql = @"DELETE FROM [TagsForSupplier] WHERE [SupplierID] = @SupplierID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierID", SupplierID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@TagID", TagID, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(TagsForSupplier model)
		{
			string strSql = @"
UPDATE [TagsForSupplier]
SET 
WHERE [SupplierID] = @SupplierID AND [TagID] = @TagID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierID", model.SupplierID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@TagID", model.TagID, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertTagsForSupplier(TagsForSupplier model)
		{
			string strSql = @"
INSERT INTO [TagsForSupplier] ([SupplierID], [TagID])
VALUES (@SupplierID, @TagID)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierID", model.SupplierID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@TagID", model.TagID, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static TagsForSupplier ConvertToModel(DbDataReader reader)
		{
			TagsForSupplier model = new TagsForSupplier();
			model.SupplierID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.TagID = reader.IsDBNull(1) ? (long)0 : reader.GetInt64(1);
			return model;
		}

		#endregion
	}
}
