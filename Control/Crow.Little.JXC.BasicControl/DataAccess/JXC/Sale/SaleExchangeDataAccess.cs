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

	public partial class SaleExchangeDataAccess
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
		public static List<SaleExchange> LoadAll()
		{
			List<SaleExchange> itemList = new List<SaleExchange>();

			string strSql = @"
SELECT [DetailID],[SaleID],[AddedPrice],[Description]
FROM [SaleExchange]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					SaleExchange model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static SaleExchange Load(string DetailID)
		{
			SaleExchange model = null;
			string strSql = @"
SELECT [DetailID],[SaleID],[AddedPrice],[Description]
FROM [SaleExchange]
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
			string strSql = @"DELETE FROM [SaleExchange] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(SaleExchange model)
		{
			string strSql = @"
UPDATE [SaleExchange]
SET 
[SaleID] = @SaleID, [AddedPrice] = @AddedPrice, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SaleID", model.SaleID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@AddedPrice", model.AddedPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertSaleExchange(SaleExchange model)
		{
			string strSql = @"
INSERT INTO [SaleExchange] ([DetailID], [SaleID], [AddedPrice], [Description])
VALUES (@DetailID, @SaleID, @AddedPrice, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@SaleID", model.SaleID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@AddedPrice", model.AddedPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static SaleExchange ConvertToModel(DbDataReader reader)
		{
			SaleExchange model = new SaleExchange();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.SaleID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.AddedPrice = reader.IsDBNull(2) ? 0 : reader.GetFloat(2);
			model.Description = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			return model;
		}

		#endregion
	}
}
