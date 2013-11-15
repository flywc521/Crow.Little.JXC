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

	public partial class DictStyleDataAccess
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
		public static List<DictStyle> LoadAll()
		{
			List<DictStyle> itemList = new List<DictStyle>();

			string strSql = @"
SELECT [ID],[StyleValue],[IsActive]
FROM [DictStyle]";
			using (DbDataReader reader = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictStyle model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictStyle Load(long ID)
		{
			DictStyle model = null;
			string strSql = @"
SELECT [ID],[StyleValue],[IsActive]
FROM [DictStyle]
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
			string strSql = @"DELETE FROM [DictStyle] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictStyle model)
		{
			string strSql = @"
UPDATE [DictStyle]
SET 
[StyleValue] = @StyleValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@StyleValue", model.StyleValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictStyle(DictStyle model)
		{
			string strSql = @"
INSERT INTO [DictStyle] ([ID], [StyleValue], [IsActive])
VALUES (@ID, @StyleValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@StyleValue", model.StyleValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictStyle ConvertToModel(DbDataReader reader)
		{
			DictStyle model = new DictStyle();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.StyleValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.IsActive = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			return model;
		}

		#endregion
	}
}
