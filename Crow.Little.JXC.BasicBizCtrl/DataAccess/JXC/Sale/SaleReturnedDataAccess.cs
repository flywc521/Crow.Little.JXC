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

	public partial class SaleReturnedDataAccess
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
		public static List<SaleReturned> LoadAll()
		{
			List<SaleReturned> itemList = new List<SaleReturned>();

			string strSql = @"
SELECT [DetailID],[SaleID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[Description]
FROM [SaleReturned]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					SaleReturned model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static SaleReturned Load(string DetailID)
		{
			SaleReturned model = null;
			string strSql = @"
SELECT [DetailID],[SaleID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[Description]
FROM [SaleReturned]
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

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

		public static bool Delete(string DetailID)
		{
			string strSql = @"DELETE FROM [SaleReturned] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(SaleReturned model)
		{
			string strSql = @"
UPDATE [SaleReturned]
SET 
[SaleID] = @SaleID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SaleID", model.SaleID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Decimal));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertSaleReturned(SaleReturned model)
		{
			string strSql = @"
INSERT INTO [SaleReturned] ([DetailID], [SaleID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice], [Description])
VALUES (@DetailID, @SaleID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SaleID", model.SaleID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Decimal));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static SaleReturned ConvertToModel(DbDataReader reader)
		{
			SaleReturned model = new SaleReturned();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.SaleID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.UnitPrice = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
			model.Description = reader.IsDBNull(7) ? String.Empty : reader.GetString(7);
			return model;
		}

		#endregion
	}
}
