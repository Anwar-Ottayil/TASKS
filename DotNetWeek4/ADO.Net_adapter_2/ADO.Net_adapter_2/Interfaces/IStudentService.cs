using ADO.Net_adapter_2.Models;
using System.Data;
namespace ADO.Net_adapter_2.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void IncreamentAllAges();
        void UpdateStudent(DataSet studentDataset);
        List<Student> FilterStudentsByAge(int age);

    }
}
