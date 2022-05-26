using System;
using System.Data.SqlClient;
using Common;
using Common.Entities;

namespace DAL
{
	public class UserRepository : IUserRepository
	{
		private string _connectionString = @"Data Source = DESKTOP-EBTTKD9\MSSQLSERVER21; Initial Catalog=ATMDB; Integrated Security = True";

		public void AddUser(User user)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "insert into Users values(@PassportSerial,@FirstName,@LastName,@BirthDay,@Email,@Tax)";
					//command.Parameters.Add(new SqlParameter("@UserId", 1));
					command.Parameters.Add(new SqlParameter("@PassportSerial", user.PassportSerial));
					command.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
					command.Parameters.Add(new SqlParameter("@LastName", user.LastName));
					command.Parameters.Add(new SqlParameter("@BirthDay", user.BirthDay));
					command.Parameters.Add(new SqlParameter("@Email", user.Email));
					command.Parameters.Add(new SqlParameter("@Tax", user.Tax));
					command.ExecuteNonQuery();
				}
			}
		}

		public User GetByPassportSerial(int userId)
		{
			User user = new User();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "Select * from Users where UserId=@Userid";
					command.Parameters.Add(new SqlParameter("@UserId", userId));
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{

							user.Id = int.Parse(reader["UserId"].ToString());
							user.PassportSerial = reader["PassportSerial"].ToString();
							user.FirstName = reader["FirstName"].ToString();
							user.LastName = reader["LastName"].ToString();
							user.BirthDay = DateTime.Parse(reader["BirthDay"].ToString());
							user.Email = reader["Email"].ToString();
							user.Tax = decimal.Parse(reader["Tax"].ToString());
						}
					}
				}
			}
			return user;
		}
	}
}
