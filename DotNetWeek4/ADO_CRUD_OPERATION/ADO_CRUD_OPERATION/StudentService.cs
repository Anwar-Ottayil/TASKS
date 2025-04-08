using ADO_CRUD_OPERATION.Models;
using Microsoft.Data.SqlClient;

namespace ADO_CRUD_OPERATION
{
    public class StudentService
    {
        private readonly string _connectionString;

        public StudentService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM STUDENT";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = Convert.ToInt32(reader["STUDENT_ID"]),
                                FirstName = reader["FIRST_NAME"].ToString(),
                                LastName = reader["LAST_NAME"].ToString(),
                                Age = Convert.ToInt32(reader["AGE"])
                            });
                        }
                    }
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "INSERT INTO STUDENT (FIRST_NAME, LAST_NAME, AGE) VALUES (@FirstName, @LastName, @Age)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "UPDATE STUDENT SET FIRST_NAME = @FirstName, LAST_NAME = @LastName, AGE = @Age WHERE STUDENT_ID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", student.StudentID);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "DELETE FROM STUDENT WHERE STUDENT_ID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
