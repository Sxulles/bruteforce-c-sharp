using Bruteforce.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruteforce.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _dbFilePath;

        public UserRepository(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        private SqliteConnection GetPhysicalDbConnection()
        {
            var dbConnection = new SqliteConnection($"Data Source ={_dbFilePath};Mode=ReadWrite");
            dbConnection.Open();
            return dbConnection;
        }

        private void ExecuteNonQuery(string query)
        {
            using var connection = GetPhysicalDbConnection();
            using var command = GetCommand(query, connection);
            command.ExecuteNonQuery();
        }

        private static SqliteCommand GetCommand(string query, SqliteConnection connection)
        {
            return new SqliteCommand
            {
                CommandText = query,
                Connection = connection,
            };
        }

        public void Add(string userName, string password)
        {
            Console.WriteLine($"{userName} - {password}");
            ExecuteNonQuery(@$"INSERT INTO users (`user_name`, `password`) VALUES ('{userName}', '{password}')");
        }

        public void Update(int id, string userName, string password)
        {
            ExecuteNonQuery(@$"UPDATE users SET user_name = {userName}, password = {password} WHERE users.id = {id}");
        }

        public void Delete(int id)
        {
            ExecuteNonQuery(@$"DELETE FROM users WHERE users.id = {id}");
        }

        public void DeleteAll()
        {
            ExecuteNonQuery(@"DELETE FROM users");
        }

        public User Get(int id)
        {
            var query = @$"SELECT * FROM users WHERE id = {id}";
            using var connection = GetPhysicalDbConnection();
            using var command = GetCommand(query, connection);

            using var reader = command.ExecuteReader();
            return new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
        }

        public IEnumerable<User> GetAll()
        {
            var query = "SELECT * FROM users";
            using var connection = GetPhysicalDbConnection();
            using var command = GetCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
        }
    }
}
