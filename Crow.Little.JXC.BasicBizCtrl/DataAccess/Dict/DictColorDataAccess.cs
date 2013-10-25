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

	public partial class DictColorDataAccess
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
		public static List<DictColor> LoadAll()
		{
			List<DictColor> itemList = new List<DictColor>();

			string strSql = @"
SELECT [ID],[ColorValue],[IsActive]
FROM [DictColor]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictColor model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictColor Load(long ID)
		{
			DictColor model = null;
			string strSql = @"
SELECT [ID],[ColorValue],[IsActive]
FROM [DictColor]
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

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

		public static bool Delete(long ID)
		{
			string strSql = @"DELETE FROM [DictColor] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictColor model)
		{
			string strSql = @"
UPDATE [DictColor]
SET 
[ColorValue] = @ColorValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ColorValue", model.ColorValue, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictColor(DictColor model)
		{
			string strSql = @"
INSERT INTO [DictColor] ([ID], [ColorValue], [IsActive])
VALUES (@ID, @ColorValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ColorValue", model.ColorValue, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictColor ConvertToModel(DbDataReader reader)
		{
			DictColor model = new DictColor();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.ColorValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.IsActive = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			return model;
		}

		#endregion
	}
}
