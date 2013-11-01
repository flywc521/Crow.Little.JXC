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

	public partial class CommodityDataAccess
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
		public static List<Commodity> LoadAll()
		{
			List<Commodity> itemList = new List<Commodity>();

			string strSql = @"
SELECT [ID],[Code],[CommodityName],[CommodityStyle],[CommodityType],[CommodityMaterial],[CommodityBrand],[IsActive],[Description]
FROM [Commodity]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					Commodity model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static Commodity Load(string ID)
		{
			Commodity model = null;
			string strSql = @"
SELECT [ID],[Code],[CommodityName],[CommodityStyle],[CommodityType],[CommodityMaterial],[CommodityBrand],[IsActive],[Description]
FROM [Commodity]
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.String));

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

		public static bool Delete(string ID)
		{
			string strSql = @"DELETE FROM [Commodity] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(Commodity model)
		{
			string strSql = @"
UPDATE [Commodity]
SET 
[Code] = @Code, [CommodityName] = @CommodityName, [CommodityStyle] = @CommodityStyle, [CommodityType] = @CommodityType, [CommodityMaterial] = @CommodityMaterial, [CommodityBrand] = @CommodityBrand, [IsActive] = @IsActive, [Description] = @Description
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Code", model.Code, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityName", model.CommodityName, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityStyle", model.CommodityStyle, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityType", model.CommodityType, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityMaterial", model.CommodityMaterial, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityBrand", model.CommodityBrand, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertCommodity(Commodity model)
		{
			string strSql = @"
INSERT INTO [Commodity] ([ID], [Code], [CommodityName], [CommodityStyle], [CommodityType], [CommodityMaterial], [CommodityBrand], [IsActive], [Description])
VALUES (@ID, @Code, @CommodityName, @CommodityStyle, @CommodityType, @CommodityMaterial, @CommodityBrand, @IsActive, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Code", model.Code, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityName", model.CommodityName, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityStyle", model.CommodityStyle, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityType", model.CommodityType, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityMaterial", model.CommodityMaterial, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityBrand", model.CommodityBrand, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@IsActive", model.IsActive, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static Commodity ConvertToModel(DbDataReader reader)
		{
			Commodity model = new Commodity();
			model.ID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.Code = reader.IsDBNull(1) ? (long)0 : reader.GetInt64(1);
			model.CommodityName = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityStyle = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommodityType = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.CommodityMaterial = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.CommodityBrand = reader.IsDBNull(6) ? (long)0 : reader.GetInt64(6);
			model.IsActive = reader.IsDBNull(7) ? (long)0 : reader.GetInt64(7);
			model.Description = reader.IsDBNull(8) ? String.Empty : reader.GetString(8);
			return model;
		}

		#endregion
	}
}
