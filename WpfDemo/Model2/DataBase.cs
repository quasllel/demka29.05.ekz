using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WpfDemo.Model2
{
    internal class DataBase
    {
        private string _connectionString = "Data Source=DEV_HUSH_PC\\MSSQLSERVER01;Initial Catalog=WpfDemo;User ID=root;Password=q1w2e3";

        public bool Auth(string username, string password)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "SELECT COUNT(*) FROM [Users] WHERE login = @username AND password = @password";

                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                        return false;
                    else
                        return true;
                }
            }
        }
        
        public string getRole(string username)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "Select role FROM Users WHERE login = @username";

                using(SqlCommand command = new SqlCommand( sqlQ, connection))
                {
                    command.Parameters.AddWithValue("username",username);

                    object result = command.ExecuteScalar();

                    if(result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return "Не определна";
                    }
                }
            }
        }
        
        public string[] getDeviceNames()
        {
            List<string> deviceNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "SELECT Name FROM Device";

                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string deviceName = reader["Name"].ToString();
                            deviceNames.Add(deviceName);
                        }
                    }
                }
            }
            return deviceNames.ToArray();
        }

       public bool updateRequest(int id, string desc, string status, string worker)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "UPDATE Requests SET description = @desc, status=@status, worker = @worker WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@worker", worker.Trim());
                    command.Parameters.AddWithValue("@desc", desc.Trim());
                    command.Parameters.AddWithValue("@status", status.Trim());
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool updateWorker(int id, string worker)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "UPDATE Requests SET worker = @worker WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@worker", worker.Trim());
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool updateFullRequest(int id, string desc, string status, string startDate, string endDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "UPDATE Requests SET description = @desc, status=@status, endDate = @endDate, startDate = @startDate WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@startDate", startDate.Trim());
                    command.Parameters.AddWithValue("@endDate", endDate.Trim());
                    command.Parameters.AddWithValue("@desc", desc.Trim());
                    command.Parameters.AddWithValue("@status", status.Trim());
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool updateOnlyDateInRequest(int id,  string startDate, string endDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "UPDATE Requests SET endDate = @endDate, startDate = @startDate WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@startDate", startDate.Trim());
                    command.Parameters.AddWithValue("@endDate", endDate.Trim());
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }



        public string[] getAllWorker()
        {
            List<string> users = new List<string>();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "SELECT login FROM Users";
                using(SqlCommand command = new SqlCommand( sqlQ, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userName = reader["login"].ToString().Trim();
                            users.Add(userName);
                        }
                    }
                }
            }

            return users.ToArray();
        }


        public string[] getAllStatus()
        {
            List<string> status = new List<string>();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "SELECT status from Status";

                using(SqlCommand command = new SqlCommand( sqlQ, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string statusName = reader["status"].ToString();
                            status.Add(statusName);
                        }
                    }
                }
                return status.ToArray();
            }
        }

        public string[] getAllReqId()
        {
            List<string> id = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "SELECT Id from Requests";

                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string statusName = reader["Id"].ToString();
                            id.Add(statusName);
                        }
                    }
                }
                return id.ToArray();
            }
        }

        public DataTable getAllReq()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "SELECT * FROM Requests";

                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
            }
        }
        public bool addNewReq(string name, string phone, string email, string device, string number, string description, string status)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQ = "INSERT INTO Requests (name, phone, email, description, number, device, status) VALUES (@name, @phone, @email, @description, @number, @device, @status)";

                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {

                    command.Parameters.AddWithValue("@name", name.Trim());
                    command.Parameters.AddWithValue("@phone", phone.Trim());
                    command.Parameters.AddWithValue("@email", email.Trim());
                    command.Parameters.AddWithValue("@device", device.Trim());
                    command.Parameters.AddWithValue("@number", number.Trim());
                    command.Parameters.AddWithValue("@description", description.Trim());
                    command.Parameters.AddWithValue("@status", status.Trim());
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}