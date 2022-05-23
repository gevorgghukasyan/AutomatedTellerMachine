using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Common;
using Common.Entities;

namespace DAL
{
	public class Repository : IRepository
	{
		private string _connectionString = @"Data Source = DESKTOP-EBTTKD9\MSSQLSERVER21; Initial Catalog=ATMDB; Integrated Security = True";

		public Card GetById(string accountNumber)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				Card card = new Card();
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "Select * from Cards where AccountNumber = @AccountNumber";
					command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							card.AccountNumber = reader["AccountNumber"].ToString();
							card.UserId = int.Parse(reader["UserId"].ToString());
							card.Password = reader["Password"].ToString();
							card.Validation = DateTime.Parse(reader["Validation"].ToString());
							card.Balance = int.Parse(reader["Balance"].ToString());
							card.Blocked = bool.Parse(reader["Blocked"].ToString());
							card.Guid = reader["Guid"].ToString();
						}
					}

				}
				return card;
			}
		}

		public List<Card> GetAllCards()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				List<Card> list = new List<Card>();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "Select * from Cards";
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Card card = new Card();
							card.AccountNumber = reader["CardId"].ToString();
							card.UserId = int.Parse(reader["UserId"].ToString());
							card.Password = reader["Password"].ToString();
							card.Validation = DateTime.Parse(reader["Validation"].ToString());
							card.Balance = int.Parse(reader["Balance"].ToString());
							card.Blocked = bool.Parse(reader["Blocked"].ToString());
							card.Guid = reader["Guid"].ToString();
							list.Add(card);

						}
					}
					return list;
				}
			}
		}

		public void UpdateCard(Card card)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "UPDATE Cards SET Balance=@Balance,Blocked=@Blocked WHERE AccountNumber=@AccountNumber";
					command.Parameters.Add(new SqlParameter("@Balance", card.Balance));
					command.Parameters.Add(new SqlParameter("@AccountNumber", card.AccountNumber));
					command.Parameters.Add(new SqlParameter("@Blocked", card.Blocked));
					command.ExecuteNonQuery();
				}
			}
		}

		public void AddCard(Card card)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "Insert into Cards values(@UserId,@AccountNumber, @Balance, @Password, @Validation, @Guid, @Blocked)";
					command.Parameters.Add(new SqlParameter("@UserId", 1));
					command.Parameters.Add(new SqlParameter("@AccountNumber", card.AccountNumber));
					command.Parameters.Add(new SqlParameter("@Balance", card.Balance));
					command.Parameters.Add(new SqlParameter("@Password", card.Password));
					command.Parameters.Add(new SqlParameter("@Validation", card.Validation));
					command.Parameters.Add(new SqlParameter("@Guid", card.Guid));
					command.Parameters.Add(new SqlParameter("@Blocked", card.Blocked));
					command.ExecuteNonQuery();
				}
			}
		}
	}
}