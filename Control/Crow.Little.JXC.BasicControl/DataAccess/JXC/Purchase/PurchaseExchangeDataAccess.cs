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

	public partial class PurchaseExchangeDataAccess
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
		public static List<PurchaseExchange> LoadAll()
		{
			List<PurchaseExchange> itemList = new List<PurchaseExchange>();

			string strSql = @"
SELECT [DetailID],[PurchaseID],[AddedPrice],[Description]
FROM [PurchaseExchange]";
			using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					PurchaseExchange model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static PurchaseExchange Load(string DetailID)
		{
			PurchaseExchange model = null;
			string strSql = @"
SELECT [DetailID],[PurchaseID],[AddedPrice],[Description]
FROM [PurchaseExchange]
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
			string strSql = @"DELETE FROM [PurchaseExchange] WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", DetailID, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(PurchaseExchange model)
		{
			string strSql = @"
UPDATE [PurchaseExchange]
SET 
[PurchaseID] = @PurchaseID, [AddedPrice] = @AddedPrice, [Description] = @Description
WHERE [DetailID] = @DetailID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@AddedPrice", model.AddedPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertPurchaseExchange(PurchaseExchange model)
		{
			string strSql = @"
INSERT INTO [PurchaseExchange] ([DetailID], [PurchaseID], [AddedPrice], [Description])
VALUES (@DetailID, @PurchaseID, @AddedPrice, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@DetailID", model.DetailID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@PurchaseID", model.PurchaseID, DbType.String));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@AddedPrice", model.AddedPrice, DbType.Double));
			paramList.Add(DBAccesser.DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static PurchaseExchange ConvertToModel(DbDataReader reader)
		{
			PurchaseExchange model = new PurchaseExchange();
			model.DetailID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.PurchaseID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.AddedPrice = reader.IsDBNull(2) ? 0 : reader.GetFloat(2);
			model.Description = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			return model;
		}

		#endregion
	}
}
