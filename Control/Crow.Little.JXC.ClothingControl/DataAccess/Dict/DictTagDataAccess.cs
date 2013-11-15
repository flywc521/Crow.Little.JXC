namespace Crow.Little.JXC.ClothingControl.DataAccess
{
	using Crow.Little.Common;
	using Crow.Little.DBHelper;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.Common;
	using System.Drawing;
	using System.Xml;
	using Crow.Little.JXC.ClothingControl.Model;

	public partial class DictTagDataAccess
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
		public static List<DictTag> LoadAll()
		{
			List<DictTag> itemList = new List<DictTag>();

			string strSql = @"
SELECT [ID],[TagValue],[IsActive]
FROM [DictTag]";
			using (DbDataReader reader = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictTag model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictTag Load(long ID)
		{
			DictTag model = null;
			string strSql = @"
SELECT [ID],[TagValue],[IsActive]
FROM [DictTag]
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			using (DbDataReader reader = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql, CommandType.Text, paramList.ToArray()))
			{
				while (reader.Read())
				{
					model = ConvertToModel(reader);
					break;
				}
			}

			return model;
		}

		public static bool Delete(long ID)
		{
			string strSql = @"DELETE FROM [DictTag] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictTag model)
		{
			string strSql = @"
UPDATE [DictTag]
SET 
[TagValue] = @TagValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagValue", model.TagValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictTag(DictTag model)
		{
			string strSql = @"
INSERT INTO [DictTag] ([ID], [TagValue], [IsActive])
VALUES (@ID, @TagValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TagValue", model.TagValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictTag ConvertToModel(DbDataReader reader)
		{
			DictTag model = new DictTag();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.TagValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.IsActive = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			return model;
		}

		#endregion
	}
}
