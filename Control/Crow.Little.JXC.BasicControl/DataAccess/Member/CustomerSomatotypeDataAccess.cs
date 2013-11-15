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

	public partial class CustomerSomatotypeDataAccess
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
		public static List<CustomerSomatotype> LoadAll()
		{
			List<CustomerSomatotype> itemList = new List<CustomerSomatotype>();

			string strSql = @"
SELECT [CustomerID],[Height],[Weight],[BustSize],[WaistSize],[HipSize]
FROM [CustomerSomatotype]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					CustomerSomatotype model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static CustomerSomatotype Load(string CustomerID)
		{
			CustomerSomatotype model = null;
			string strSql = @"
SELECT [CustomerID],[Height],[Weight],[BustSize],[WaistSize],[HipSize]
FROM [CustomerSomatotype]
WHERE [CustomerID] = @CustomerID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", CustomerID, DbType.String));

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

		public static bool Delete(string CustomerID)
		{
			string strSql = @"DELETE FROM [CustomerSomatotype] WHERE [CustomerID] = @CustomerID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", CustomerID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(CustomerSomatotype model)
		{
			string strSql = @"
UPDATE [CustomerSomatotype]
SET 
[Height] = @Height, [Weight] = @Weight, [BustSize] = @BustSize, [WaistSize] = @WaistSize, [HipSize] = @HipSize
WHERE [CustomerID] = @CustomerID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", model.CustomerID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Height", model.Height, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Weight", model.Weight, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@BustSize", model.BustSize, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@WaistSize", model.WaistSize, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@HipSize", model.HipSize, DbType.Double));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertCustomerSomatotype(CustomerSomatotype model)
		{
			string strSql = @"
INSERT INTO [CustomerSomatotype] ([CustomerID], [Height], [Weight], [BustSize], [WaistSize], [HipSize])
VALUES (@CustomerID, @Height, @Weight, @BustSize, @WaistSize, @HipSize)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@CustomerID", model.CustomerID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Height", model.Height, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Weight", model.Weight, DbType.Int64));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@BustSize", model.BustSize, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@WaistSize", model.WaistSize, DbType.Double));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@HipSize", model.HipSize, DbType.Double));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static CustomerSomatotype ConvertToModel(DbDataReader reader)
		{
			CustomerSomatotype model = new CustomerSomatotype();
			model.CustomerID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.Height = reader.IsDBNull(1) ? (long)0 : reader.GetInt64(1);
			model.Weight = reader.IsDBNull(2) ? (long)0 : reader.GetInt64(2);
			model.BustSize = reader.IsDBNull(3) ? 0 : reader.GetFloat(3);
			model.WaistSize = reader.IsDBNull(4) ? 0 : reader.GetFloat(4);
			model.HipSize = reader.IsDBNull(5) ? 0 : reader.GetFloat(5);
			return model;
		}

		#endregion
	}
}
