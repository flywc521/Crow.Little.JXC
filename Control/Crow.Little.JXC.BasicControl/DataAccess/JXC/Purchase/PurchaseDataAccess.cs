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

	public partial class PurchaseDataAccess
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
		public static List<Purchase> LoadAll()
		{
			List<Purchase> itemList = new List<Purchase>();

			string strSql = @"
SELECT [ID],[PurchaseDate],[OperatorID],[SupplierID],[Description]
FROM [Purchase]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					Purchase model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static Purchase Load(string ID)
		{
			Purchase model = null;
			string strSql = @"
SELECT [ID],[PurchaseDate],[OperatorID],[SupplierID],[Description]
FROM [Purchase]
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.String));

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

		public static bool Delete(string ID)
		{
			string strSql = @"DELETE FROM [Purchase] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(Purchase model)
		{
			string strSql = @"
UPDATE [Purchase]
SET 
[PurchaseDate] = @PurchaseDate, [OperatorID] = @OperatorID, [SupplierID] = @SupplierID, [Description] = @Description
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@PurchaseDate", model.PurchaseDate, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@OperatorID", model.OperatorID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@SupplierID", model.SupplierID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchase(Purchase model)
		{
			string strSql = @"
INSERT INTO [Purchase] ([ID], [PurchaseDate], [OperatorID], [SupplierID], [Description])
VALUES (@ID, @PurchaseDate, @OperatorID, @SupplierID, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@PurchaseDate", model.PurchaseDate, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@OperatorID", model.OperatorID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@SupplierID", model.SupplierID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static Purchase ConvertToModel(DbDataReader reader)
		{
			Purchase model = new Purchase();
			model.ID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.PurchaseDate = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.OperatorID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.SupplierID = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			model.Description = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
			return model;
		}

		#endregion
	}
}
