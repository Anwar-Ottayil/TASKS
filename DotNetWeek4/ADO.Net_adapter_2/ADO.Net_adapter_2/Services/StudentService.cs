using ADO.Net_adapter_2.Interfaces;
using ADO.Net_adapter_2.Models;
using System.Data;
using System.Data.SqlClient;
namespace ADO.Net_adapter_2.Services
{
    public class StudentService : IStudentService
    {
        private readonly string _connectionString;
        public StudentService(IConfiguration configuration)

        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<Student> GetAllStudents()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Student", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Student");
                var studentsTable = dataSet.Tables["Student"];
                var students = studentsTable.AsEnumerable().Select(row => new Student
                {
                    Id = row.Field<int>("Id"),
                    Name = row.Field<string>("Name"),
                    Age = row.Field<int>("Age")
                }).ToList();
                return students;
            }
        }
        private DataSet GetStudentDataSet()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Student", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Student");
                return dataSet;
            }
        }
        public void UpdateStudent(DataSet studentDataset)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Student", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(studentDataset, "Student");
            }
        }
        public void IncreamentAllAges()
        {
            DataSet DataSet = GetStudentDataSet();
            DataTable studentsTable = DataSet.Tables["Student"];
            foreach (DataRow row in studentsTable.Rows)
            {
                row["Age"] = (int)row["Age"] + 1;
            }
            UpdateStudent(DataSet);

        }
        public List<Student> FilterStudentsByAge(int age)
        {
            DataSet DataSet = GetStudentDataSet();
            DataTable studentsTable = DataSet.Tables["Student"];
            DataView view = new DataView(studentsTable);
            {
              view.RowFilter = $"Age = {age}";
            };

            List<Student> filteredStudents = new List<Student>();
            foreach (DataRowView row in view)
            {
                filteredStudents.Add(new Student
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Age = (int)row["Age"]
                });
            }
            return filteredStudents;
        }
    }
}