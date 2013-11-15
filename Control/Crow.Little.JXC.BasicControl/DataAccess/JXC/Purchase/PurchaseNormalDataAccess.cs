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

	public partial class PurchaseNormalDataAccess
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
		public static List<PurchaseNormal> LoadAll()
		{
			List<PurchaseNormal> itemList = new List<PurchaseNormal>();

			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[ReferencePrice],[Description]
FROM [PurchaseNormal]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseNormal model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseNormal Load(string DetailID)
		{
			PurchaseNormal model = null;
			string strSql = @"
SELECT [DetailID],[PurchaseID],[CommodityID],[CommodityColor],[CommoditySize],[Quantity],[UnitPrice],[ReferencePrice],[Description]
FROM [PurchaseNormal]
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
			string strSql = @"DELETE FROM [PurchaseNormal] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseNormal model)
		{
			string strSql = @"
UPDATE [PurchaseNormal]
SET 
[PurchaseID] = @PurchaseID, [CommodityID] = @CommodityID, [CommodityColor] = @CommodityColor, [CommoditySize] = @CommoditySize, [Quantity] = @Quantity, [UnitPrice] = @UnitPrice, [ReferencePrice] = @ReferencePrice, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ReferencePrice", model.ReferencePrice, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseNormal(PurchaseNormal model)
		{
			string strSql = @"
INSERT INTO [PurchaseNormal] ([DetailID], [PurchaseID], [CommodityID], [CommodityColor], [CommoditySize], [Quantity], [UnitPrice], [ReferencePrice], [Description])
VALUES (@DetailID, @PurchaseID, @CommodityID, @CommodityColor, @CommoditySize, @Quantity, @UnitPrice, @ReferencePrice, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityID", model.CommodityID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommodityColor", model.CommodityColor, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CommoditySize", model.CommoditySize, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Quantity", model.Quantity, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@UnitPrice", model.UnitPrice, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ReferencePrice", model.ReferencePrice, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseNormal ConvertToModel(DbDataReader reader)
		{
			PurchaseNormal model = new PurchaseNormal();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.PurchaseID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CommodityID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CommodityColor = reader.IsDBNull(3) ? (long)0 : reader.GetInt64(3);
			model.CommoditySize = reader.IsDBNull(4) ? (long)0 : reader.GetInt64(4);
			model.Quantity = reader.IsDBNull(5) ? (long)0 : reader.GetInt64(5);
			model.UnitPrice = reader.IsDBNull(6) ? 0 : reader.GetFloat(6);
			model.ReferencePrice = reader.IsDBNull(7) ? 0 : reader.GetFloat(7);
			model.Description = reader.IsDBNull(8) ? String.Empty : reader.GetString(8);
			return model;
		}

		#endregion
	}
}
