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

	public partial class DictSizeDataAccess
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
		public static List<DictSize> LoadAll()
		{
			List<DictSize> itemList = new List<DictSize>();

			string strSql = @"
SELECT [ID],[SizeValue],[StandardSizeValue],[IsActive]
FROM [DictSize]";
			using (DbDataReader reader = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictSize model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictSize Load(long ID)
		{
			DictSize model = null;
			string strSql = @"
SELECT [ID],[SizeValue],[StandardSizeValue],[IsActive]
FROM [DictSize]
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
			string strSql = @"DELETE FROM [DictSize] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictSize model)
		{
			string strSql = @"
UPDATE [DictSize]
SET 
[SizeValue] = @SizeValue, [StandardSizeValue] = @StandardSizeValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@SizeValue", model.SizeValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@StandardSizeValue", model.StandardSizeValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictSize(DictSize model)
		{
			string strSql = @"
INSERT INTO [DictSize] ([ID], [SizeValue], [StandardSizeValue], [IsActive])
VALUES (@ID, @SizeValue, @StandardSizeValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@SizeValue", model.SizeValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@StandardSizeValue", model.StandardSizeValue, DbType.String));
			paramList.Add(CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = CommonSingleton<ClothingMajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictSize ConvertToModel(DbDataReader reader)
		{
			DictSize model = new DictSize();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.SizeValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.StandardSizeValue = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.IsActive = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			return model;
		}

		#endregion
	}
}
