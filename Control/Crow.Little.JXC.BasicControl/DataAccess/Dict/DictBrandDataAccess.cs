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

	public partial class DictBrandDataAccess
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
		public static List<DictBrand> LoadAll()
		{
			List<DictBrand> itemList = new List<DictBrand>();

			string strSql = @"
SELECT [ID],[BrandValue],[IsActive]
FROM [DictBrand]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					DictBrand model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static DictBrand Load(long ID)
		{
			DictBrand model = null;
			string strSql = @"
SELECT [ID],[BrandValue],[IsActive]
FROM [DictBrand]
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
			string strSql = @"DELETE FROM [DictBrand] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(DictBrand model)
		{
			string strSql = @"
UPDATE [DictBrand]
SET 
[BrandValue] = @BrandValue, [IsActive] = @IsActive
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@BrandValue", model.BrandValue, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertDictBrand(DictBrand model)
		{
			string strSql = @"
INSERT INTO [DictBrand] ([ID], [BrandValue], [IsActive])
VALUES (@ID, @BrandValue, @IsActive)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@BrandValue", model.BrandValue, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static DictBrand ConvertToModel(DbDataReader reader)
		{
			DictBrand model = new DictBrand();
			model.ID = reader.IsDBNull(0) ? (long)0 : reader.GetInt64(0);
			model.BrandValue = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.IsActive = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			return model;
		}

		#endregion
	}
}
