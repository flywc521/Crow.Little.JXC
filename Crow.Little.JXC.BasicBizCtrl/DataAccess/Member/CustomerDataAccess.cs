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

	public partial class CustomerDataAccess
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
		public static List<Customer> LoadAll()
		{
			List<Customer> itemList = new List<Customer>();

			string strSql = @"
SELECT [ID],[CustomerName],[CustomerTel],[CustomerMobile],[CustomerAddress],[Description]
FROM [Customer]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					Customer model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static Customer Load(string ID)
		{
			Customer model = null;
			string strSql = @"
SELECT [ID],[CustomerName],[CustomerTel],[CustomerMobile],[CustomerAddress],[Description]
FROM [Customer]
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.String));

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

		public static bool Delete(string ID)
		{
			string strSql = @"DELETE FROM [Customer] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(Customer model)
		{
			string strSql = @"
UPDATE [Customer]
SET 
[CustomerName] = @CustomerName, [CustomerTel] = @CustomerTel, [CustomerMobile] = @CustomerMobile, [CustomerAddress] = @CustomerAddress, [Description] = @Description
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerName", model.CustomerName, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerTel", model.CustomerTel, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerMobile", model.CustomerMobile, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerAddress", model.CustomerAddress, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertCustomer(Customer model)
		{
			string strSql = @"
INSERT INTO [Customer] ([ID], [CustomerName], [CustomerTel], [CustomerMobile], [CustomerAddress], [Description])
VALUES (@ID, @CustomerName, @CustomerTel, @CustomerMobile, @CustomerAddress, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerName", model.CustomerName, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerTel", model.CustomerTel, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerMobile", model.CustomerMobile, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@CustomerAddress", model.CustomerAddress, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static Customer ConvertToModel(DbDataReader reader)
		{
			Customer model = new Customer();
			model.ID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.CustomerName = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.CustomerTel = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.CustomerMobile = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			model.CustomerAddress = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
			model.Description = reader.IsDBNull(5) ? String.Empty : reader.GetString(5);
			return model;
		}

		#endregion
	}
}
