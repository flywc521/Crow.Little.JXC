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

	public partial class DictTypeDataAccess
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
		public static List<DictType> LoadAll()
		{
			List<DictType> itemList = new List<DictType>();

			string strSql = @"
SELECT [ID],[TypeValue],[IsActive]
FROM [DictType]";
            using (DbDataReader reader = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictType model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictType Load(long ID)
		{
			DictType model = null;
			string strSql = @"
SELECT [ID],[TypeValue],[IsActive]
FROM [DictType]
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
			string strSql = @"DELETE FROM [DictType] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictType model)
		{
			string strSql = @"
UPDATE [DictType]
SET 
[TypeValue] = @TypeValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TypeValue", model.TypeValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictType(DictType model)
		{
			string strSql = @"
INSERT INTO [DictType] ([ID], [TypeValue], [IsActive])
VALUES (@ID, @TypeValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@TypeValue", model.TypeValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictType ConvertToModel(DbDataReader reader)
		{
			DictType model = new DictType();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.TypeValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.IsActive = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			return model;
		}

		#endregion
	}
}
