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

	public partial class SaleExchangeToDataAccess
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
		public static List<SaleExchangeTo> LoadAll()
		{
			List<SaleExchangeTo> itemList = new List<SaleExchangeTo>();

			string strSql = @"
SELECT [ToID],[DetailID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice]
FROM [SaleExchangeTo]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					SaleExchangeTo model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static SaleExchangeTo Load(string ToID)
		{
			SaleExchangeTo model = null;
			string strSql = @"
SELECT [ToID],[DetailID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice]
FROM [SaleExchangeTo]
WHERE [ToID] = @ToID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ToID", ToID, DbType.String));

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

		public static bool Delete(string ToID)
		{
			string strSql = @"DELETE FROM [SaleExchangeTo] WHERE [ToID] = @ToID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ToID", ToID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(SaleExchangeTo model)
		{
			string strSql = @"
UPDATE [SaleExchangeTo]
SET 
[DetailID] = @DetailID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice
WHERE [ToID] = @ToID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ToID", model.ToID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertSaleExchangeTo(SaleExchangeTo model)
		{
			string strSql = @"
INSERT INTO [SaleExchangeTo] ([ToID], [DetailID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice])
VALUES (@ToID, @DetailID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ToID", model.ToID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static SaleExchangeTo ConvertToModel(DbDataReader reader)
		{
			SaleExchangeTo model = new SaleExchangeTo();
			model.ToID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
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
