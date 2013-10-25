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

	public partial class SupplierDataAccess
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
		public static List<Supplier> LoadAll()
		{
			List<Supplier> itemList = new List<Supplier>();

			string strSql = @"
SELECT [ID],[SupplierName],[SupplierTel],[SupplierMobile],[SupplierAddress],[SupplierZipCode],[Description]
FROM [Supplier]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					Supplier model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static Supplier Load(string ID)
		{
			Supplier model = null;
			string strSql = @"
SELECT [ID],[SupplierName],[SupplierTel],[SupplierMobile],[SupplierAddress],[SupplierZipCode],[Description]
FROM [Supplier]
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
			string strSql = @"DELETE FROM [Supplier] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", ID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(Supplier model)
		{
			string strSql = @"
UPDATE [Supplier]
SET 
[SupplierName] = @SupplierName, [SupplierTel] = @SupplierTel, [SupplierMobile] = @SupplierMobile, [SupplierAddress] = @SupplierAddress, [SupplierZipCode] = @SupplierZipCode, [Description] = @Description
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierName", model.SupplierName, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierTel", model.SupplierTel, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierMobile", model.SupplierMobile, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierAddress", model.SupplierAddress, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierZipCode", model.SupplierZipCode, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertSupplier(Supplier model)
		{
			string strSql = @"
INSERT INTO [Supplier] ([ID], [SupplierName], [SupplierTel], [SupplierMobile], [SupplierAddress], [SupplierZipCode], [Description])
VALUES (@ID, @SupplierName, @SupplierTel, @SupplierMobile, @SupplierAddress, @SupplierZipCode, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierName", model.SupplierName, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierTel", model.SupplierTel, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierMobile", model.SupplierMobile, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierAddress", model.SupplierAddress, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SupplierZipCode", model.SupplierZipCode, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static Supplier ConvertToModel(DbDataReader reader)
		{
			Supplier model = new Supplier();
			model.ID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.SupplierName = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.SupplierTel = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.SupplierMobile = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			model.SupplierAddress = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
			model.SupplierZipCode = reader.IsDBNull(5) ? String.Empty : reader.GetString(5);
			model.Description = reader.IsDBNull(6) ? String.Empty : reader.GetString(6);
			return model;
		}

		#endregion
	}
}
