using CrudApplicationWithAllControl.Models;
using System.Data;
using System.Data.SqlClient;

namespace CrudApplicationWithAllControl.Repository
{
    public class StudentRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration Configuration;
        public StudentRepo(IConfiguration _configuration)
        {

            Configuration = _configuration;
            _connectionString = this.Configuration.GetConnectionString("DefaultConnection");

        }

        public void StudentAdd(StudentModel sm)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("AddStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", sm.name);
            command.Parameters.AddWithValue("@Address", sm.Address);
            command.Parameters.AddWithValue("@phonenumber", sm.phonenumber);
            command.Parameters.AddWithValue("@email", sm.email);
            command.Parameters.AddWithValue("@image", sm.imageFileName);
            command.Parameters.AddWithValue("@country", sm.country);
            command.Parameters.AddWithValue("@Hobby", sm.Hobby);
            command.Parameters.AddWithValue("@Gender", sm.Gender);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<StudentModel> GetStudents()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("ViewStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            var users = new List<StudentModel>();
            while (reader.Read())
            {
                users.Add(new StudentModel
                {
                    name = reader["name"].ToString(),
                    Address = reader["Address"].ToString(),
                    phonenumber = reader["phonenumber"].ToString(),
                    email = reader["email"].ToString(),
                    imageFileName = reader["image"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                    country = reader["country"].ToString(),
                    Hobby = reader["Hobby"].ToString(),
                    Gender = reader["Gender"].ToString()
                });
            }
            connection.Close();
            return users;
        }

        public StudentModel GetStudentsById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM person WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            var users = new StudentModel();
            while (reader.Read())
            {
                //users.name = reader["name"].ToString()
                //users.Add(new StudentModel
                //{
                users.name = reader["name"].ToString();
                users.Address = reader["Address"].ToString();
                users.phonenumber = reader["phonenumber"].ToString();
                users.email = reader["email"].ToString();
                users.imageFileName = reader["image"].ToString();
                users.Id = Convert.ToInt32(reader["Id"]);
                users.country = reader["country"].ToString();
                users.Selected = reader["country"].ToString();
                users.Gender = reader["Gender"].ToString();
                users.Hobby = reader["Hobby"].ToString();
                users.Checkedproperties = reader["Gender"].ToString();
                //});
            }
            connection.Close();
            return users;
        }

        public List<StudentModel> AllCountry()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand("select * from Country", connection);
            SqlDataReader reader = command.ExecuteReader();
            var getitems = new List<StudentModel>();
            while (reader.Read())
            {
                getitems.Add(new StudentModel
                {
                    CId = reader["cid"].ToString(),
                    CName = reader["countryname"].ToString()
                });
            }
            connection.Close();
            return getitems;
        }

        public void DeleteStudentsById(int id)
        {
           SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand("DELETE FROM person WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool UpdateStudentsById(StudentModel esm)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("ModifyStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name1", esm.name);
            command.Parameters.AddWithValue("@Address1", esm.Address);
            command.Parameters.AddWithValue("@phonenumber1", esm.phonenumber);
            command.Parameters.AddWithValue("@email1", esm.email);
            command.Parameters.AddWithValue("@image1", esm.imageFileName);
            command.Parameters.AddWithValue("@country1", esm.country);
            command.Parameters.AddWithValue("@Hobby1", esm.Hobby);
            command.Parameters.AddWithValue("@Gender1", esm.Gender);
            command.Parameters.AddWithValue("@Idd", esm.Id);
            if (esm.Id > 0)
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
    }
}
