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

	public partial class PurchaseExchangeToDataAccess
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
		public static List<PurchaseExchangeTo> LoadAll()
		{
			List<PurchaseExchangeTo> itemList = new List<PurchaseExchangeTo>();

			string strSql = @"
SELECT [ToID],[DetailID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[ReferencePrice]
FROM [PurchaseExchangeTo]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseExchangeTo model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseExchangeTo Load(string ToID)
		{
			PurchaseExchangeTo model = null;
			string strSql = @"
SELECT [ToID],[DetailID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[ReferencePrice]
FROM [PurchaseExchangeTo]
WHERE [ToID] = @ToID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ToID", ToID, DbType.String));

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

		public static bool Delete(string ToID)
		{
			string strSql = @"DELETE FROM [PurchaseExchangeTo] WHERE [ToID] = @ToID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ToID", ToID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseExchangeTo model)
		{
			string strSql = @"
UPDATE [PurchaseExchangeTo]
SET 
[DetailID] = @DetailID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice, [ReferencePrice] = @ReferencePrice
WHERE [ToID] = @ToID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ToID", model.ToID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ReferencePrice", model.ReferencePrice, DbType.Double));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseExchangeTo(PurchaseExchangeTo model)
		{
			string strSql = @"
INSERT INTO [PurchaseExchangeTo] ([ToID], [DetailID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice], [ReferencePrice])
VALUES (@ToID, @DetailID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice, @ReferencePrice)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ToID", model.ToID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ReferencePrice", model.ReferencePrice, DbType.Double));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseExchangeTo ConvertToModel(DbDataReader reader)
		{
			PurchaseExchangeTo model = new PurchaseExchangeTo();
			model.ToID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.DetailID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.UnitPrice = reader.IsDBNull(6) ? 0 : reader.GetFloat(6);
			model.ReferencePrice = reader.IsDBNull(7) ? 0 : reader.GetFloat(7);
			return model;
		}

		#endregion
	}
}
