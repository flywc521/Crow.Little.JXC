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

	public partial class EmployeeDataAccess
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
		public static List<Employee> LoadAll()
		{
			List<Employee> itemList = new List<Employee>();

			string strSql = @"
SELECT [ID],[EmployeeName],[EmployeeTel],[EmployeeMobile],[LoginName],[Password]
FROM [Employee]";
			using (DbDataReader reader = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteReader(strSql))
			{
				while (reader.Read())
				{
					Employee model = ConvertToModel(reader);
					itemList.Add(model);
				}
			}

			return itemList;
		}

		public static Employee Load(string ID)
		{
			Employee model = null;
			string strSql = @"
SELECT [ID],[EmployeeName],[EmployeeTel],[EmployeeMobile],[LoginName],[Password]
FROM [Employee]
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
			string strSql = @"DELETE FROM [Employee] WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", ID, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool Update(Employee model)
		{
			string strSql = @"
UPDATE [Employee]
SET 
[EmployeeName] = @EmployeeName, [EmployeeTel] = @EmployeeTel, [EmployeeMobile] = @EmployeeMobile, [LoginName] = @LoginName, [Password] = @Password
WHERE [ID] = @ID ";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@EmployeeName", model.EmployeeName, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@EmployeeTel", model.EmployeeTel, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@EmployeeMobile", model.EmployeeMobile, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@LoginName", model.LoginName, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Password", model.Password, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static bool InsertEmployee(Employee model)
		{
			string strSql = @"
INSERT INTO [Employee] ([ID], [EmployeeName], [EmployeeTel], [EmployeeMobile], [LoginName], [Password])
VALUES (@ID, @EmployeeName, @EmployeeTel, @EmployeeMobile, @LoginName, @Password)";
			List<DbParameter> paramList = new List<DbParameter>();
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@ID", model.ID, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@EmployeeName", model.EmployeeName, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@EmployeeTel", model.EmployeeTel, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@EmployeeMobile", model.EmployeeMobile, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@LoginName", model.LoginName, DbType.String));
			paramList.Add(CommonSingleton<MajorAssistant>.GetInstance().DbInstance.BuildDbParameter("@Password", model.Password, DbType.String));

			int res = CommonSingleton<MajorAssistant>.GetInstance().DbInstance.ExecuteNonQuery(strSql, CommandType.Text, paramList.ToArray());
			return res > 0 ; 
		}

		public static Employee ConvertToModel(DbDataReader reader)
		{
			Employee model = new Employee();
			model.ID = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
			model.EmployeeName = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
			model.EmployeeTel = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
			model.EmployeeMobile = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
			model.LoginName = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
			model.Password = reader.IsDBNull(5) ? String.Empty : reader.GetString(5);
			return model;
		}

		#endregion
	}
}
