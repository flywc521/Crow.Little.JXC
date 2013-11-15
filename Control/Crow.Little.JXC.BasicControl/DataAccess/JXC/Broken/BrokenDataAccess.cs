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

	public partial class BrokenDataAccess
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
		public static List<Broken> LoadAll()
		{
			List<Broken> itemList = new List<Broken>();

			string strSql = @"
SELECT [ID],[BrokenDate],[OperatorID],[Description]
FROM [Broken]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					Broken model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static Broken Load(string ID)
		{
			Broken model = null;
			string strSql = @"
SELECT [ID],[BrokenDate],[OperatorID],[Description]
FROM [Broken]
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
			string strSql = @"DELETE FROM [Broken] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(Broken model)
		{
			string strSql = @"
UPDATE [Broken]
SET 
[BrokenDate] = @BrokenDate, [OperatorID] = @OperatorID, [Description] = @Description
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@BrokenDate", model.BrokenDate, DbType.DateTime));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@OperatorID", model.OperatorID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertBroken(Broken model)
		{
			string strSql = @"
INSERT INTO [Broken] ([ID], [BrokenDate], [OperatorID], [Description])
VALUES (@ID, @BrokenDate, @OperatorID, @Description)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@BrokenDate", model.BrokenDate, DbType.DateTime));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@OperatorID", model.OperatorID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Description", model.Description, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static Broken ConvertToModel(DbDataReader reader)
		{
			Broken model = new Broken();
			model.ID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.BrokenDate = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1);
			model.OperatorID = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.Description = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			return model;
		}

		#endregion
	}
}
