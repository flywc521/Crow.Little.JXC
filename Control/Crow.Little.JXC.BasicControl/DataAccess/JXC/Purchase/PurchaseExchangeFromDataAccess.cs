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

	public partial class PurchaseExchangeFromDataAccess
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
		public static List<PurchaseExchangeFrom> LoadAll()
		{
			List<PurchaseExchangeFrom> itemList = new List<PurchaseExchangeFrom>();

			string strSql = @"
SELECT [FromID],[DetailID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice]
FROM [PurchaseExchangeFrom]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseExchangeFrom model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseExchangeFrom Load(string FromID)
		{
			PurchaseExchangeFrom model = null;
			string strSql = @"
SELECT [FromID],[DetailID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice]
FROM [PurchaseExchangeFrom]
WHERE [FromID] = @FromID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@FromID", FromID, DbType.String));

			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql, CommandType.Text, paramList.ToArray()))
			{
				while (reader.Read())
				{
					model = ConvertToModel(reader);
					break;
				}
			}

			return model;
		}

		public static bool Delete(string FromID)
		{
			string strSql = @"DELETE FROM [PurchaseExchangeFrom] WHERE [FromID] = @FromID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@FromID", FromID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseExchangeFrom model)
		{
			string strSql = @"
UPDATE [PurchaseExchangeFrom]
SET 
[DetailID] = @DetailID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice
WHERE [FromID] = @FromID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@FromID", model.FromID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseExchangeFrom(PurchaseExchangeFrom model)
		{
			string strSql = @"
INSERT INTO [PurchaseExchangeFrom] ([FromID], [DetailID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice])
VALUES (@FromID, @DetailID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@FromID", model.FromID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseExchangeFrom ConvertToModel(DbDataReader reader)
		{
			PurchaseExchangeFrom model = new PurchaseExchangeFrom();
			model.FromID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.DetailID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.UnitPrice = reader.IsDBNull(6) ? 0 : reader.GetFloat(6);
			return model;
		}

		#endregion
	}
}
