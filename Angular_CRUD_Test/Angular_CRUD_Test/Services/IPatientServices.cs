using Angular_CRUD_Test.Models;

namespace Angular_CRUD_Test.Services
{
    public interface IPatientServices
    {
        IEnumerable<Patient> GetAllPatients(string ssearchByFirstName);
        Patient GetPatientById(int id);
        void AddPatient(PatientReqModel patient);
        void UpdatePatient(PatientReqModel patient);
        void DeletePatient(int id);
    }
}
