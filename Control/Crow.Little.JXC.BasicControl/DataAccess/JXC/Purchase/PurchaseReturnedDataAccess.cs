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

	public partial class PurchaseReturnedDataAccess
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
		public static List<PurchaseReturned> LoadAll()
		{
			List<PurchaseReturned> itemList = new List<PurchaseReturned>();

			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[Description]
FROM [PurchaseReturned]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseReturned model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseReturned Load(string DetailID)
		{
			PurchaseReturned model = null;
			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[Description]
FROM [PurchaseReturned]
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
			string strSql = @"DELETE FROM [PurchaseReturned] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseReturned model)
		{
			string strSql = @"
UPDATE [PurchaseReturned]
SET 
[PurchaseID] = @PurchaseID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseReturned(PurchaseReturned model)
		{
			string strSql = @"
INSERT INTO [PurchaseReturned] ([DetailID], [PurchaseID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice], [Description])
VALUES (@DetailID, @PurchaseID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseReturned ConvertToModel(DbDataReader reader)
		{
			PurchaseReturned model = new PurchaseReturned();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.PurchaseID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.UnitPrice = reader.IsDBNull(6) ? 0 : reader.GetFloat(6);
			model.Description = reader.IsDBNull(7) ? String.Empty : reader.GetString(7);
			return model;
		}

		#endregion
	}
}
