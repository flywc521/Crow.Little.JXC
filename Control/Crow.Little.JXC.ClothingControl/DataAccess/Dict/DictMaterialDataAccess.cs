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

	public partial class DictMaterialDataAccess
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
		public static List<DictMaterial> LoadAll()
		{
			List<DictMaterial> itemList = new List<DictMaterial>();

			string strSql = @"
SELECT [ID],[MaterialValue],[IsActive]
FROM [DictMaterial]";
			using (DbDataReader reader = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictMaterial model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictMaterial Load(long ID)
		{
			DictMaterial model = null;
			string strSql = @"
SELECT [ID],[MaterialValue],[IsActive]
FROM [DictMaterial]
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
			string strSql = @"DELETE FROM [DictMaterial] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictMaterial model)
		{
			string strSql = @"
UPDATE [DictMaterial]
SET 
[MaterialValue] = @MaterialValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@MaterialValue", model.MaterialValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictMaterial(DictMaterial model)
		{
			string strSql = @"
INSERT INTO [DictMaterial] ([ID], [MaterialValue], [IsActive])
VALUES (@ID, @MaterialValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@MaterialValue", model.MaterialValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictMaterial ConvertToModel(DbDataReader reader)
		{
			DictMaterial model = new DictMaterial();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.MaterialValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.IsActive = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			return model;
		}

		#endregion
	}
}
