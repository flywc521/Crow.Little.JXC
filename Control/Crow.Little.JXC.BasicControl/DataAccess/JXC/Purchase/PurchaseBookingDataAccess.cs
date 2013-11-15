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

	public partial class PurchaseBookingDataAccess
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
		public static List<PurchaseBooking> LoadAll()
		{
			List<PurchaseBooking> itemList = new List<PurchaseBooking>();

			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[BookingPrice],[IsPayed],[Description]
FROM [PurchaseBooking]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseBooking model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseBooking Load(string DetailID)
		{
			PurchaseBooking model = null;
			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[BookingPrice],[IsPayed],[Description]
FROM [PurchaseBooking]
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

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

		public static bool Delete(string DetailID)
		{
			string strSql = @"DELETE FROM [PurchaseBooking] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseBooking model)
		{
			string strSql = @"
UPDATE [PurchaseBooking]
SET 
[PurchaseID] = @PurchaseID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [BookingPrice] = @BookingPrice, [IsPayed] = @IsPayed, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@BookingPrice", model.BookingPrice, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsPayed", model.IsPayed, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseBooking(PurchaseBooking model)
		{
			string strSql = @"
INSERT INTO [PurchaseBooking] ([DetailID], [PurchaseID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [BookingPrice], [IsPayed], [Description])
VALUES (@DetailID, @PurchaseID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @BookingPrice, @IsPayed, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@BookingPrice", model.BookingPrice, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@IsPayed", model.IsPayed, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseBooking ConvertToModel(DbDataReader reader)
		{
			PurchaseBooking model = new PurchaseBooking();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.PurchaseID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.BookingPrice = reader.IsDBNull(6) ? 0 : reader.GetFloat(6);
			model.IsPayed = reader.IsDBNull(7) ? (long)0 : reader.GetInt64(7);
			model.Description = reader.IsDBNull(8) ? String.Empty : reader.GetString(8);
			return model;
		}

		#endregion
	}
}
