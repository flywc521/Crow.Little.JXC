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

	public partial class PurchaseAddedDataAccess
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
		public static List<PurchaseAdded> LoadAll()
		{
			List<PurchaseAdded> itemList = new List<PurchaseAdded>();

			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[ReferencePrice],[Description]
FROM [PurchaseAdded]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseAdded model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseAdded Load(string DetailID)
		{
			PurchaseAdded model = null;
			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[ReferencePrice],[Description]
FROM [PurchaseAdded]
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
			string strSql = @"DELETE FROM [PurchaseAdded] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseAdded model)
		{
			string strSql = @"
UPDATE [PurchaseAdded]
SET 
[PurchaseID] = @PurchaseID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice, [ReferencePrice] = @ReferencePrice, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Decimal));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ReferencePrice", model.ReferencePrice, DbType.Decimal));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseAdded(PurchaseAdded model)
		{
			string strSql = @"
INSERT INTO [PurchaseAdded] ([DetailID], [PurchaseID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice], [ReferencePrice], [Description])
VALUES (@DetailID, @PurchaseID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice, @ReferencePrice, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Decimal));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ReferencePrice", model.ReferencePrice, DbType.Decimal));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseAdded ConvertToModel(DbDataReader reader)
		{
			PurchaseAdded model = new PurchaseAdded();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.PurchaseID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.UnitPrice = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
			model.ReferencePrice = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
			model.Description = reader.IsDBNull(8) ? String.Empty : reader.GetString(8);
			return model;
		}

		#endregion
	}
}
