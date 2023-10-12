using Angular_CRUD_Test.Context;
using Angular_CRUD_Test.Models;

namespace Angular_CRUD_Test.Services
{
    public class PatientService : IPatientServices
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAllPatients(string searchByFirstName)
        {
            if (string.IsNullOrWhiteSpace(searchByFirstName))
            {
                return _context.Patients.ToList();
            }
            else
            {
                return _context.Patients.Where(c => c.FirstName.Contains(searchByFirstName)).ToList();
            }
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.Find(id);
        }

        public void AddPatient(PatientReqModel patient)
        {
            Patient patientData = new Patient();
            patientData.FirstName = patient?.firstName;
            patientData.LastName = patient?.lastName;
            patientData.AddressLine1 = patient?.addressLine1;
            patientData.AddressLine2 = patient?.addressLine2;
            patientData.City = patient?.city;
            patientData.State = patient?.state;
            patientData.ZipCode = patient?.zipCode;
            patientData.Email = patient?.email;
            patientData.Phone = patient?.phone;
            _context.Patients.Add(patientData);
            _context.SaveChanges();
        }

        public void UpdatePatient(PatientReqModel patient)
        {

            var patientdetails = _context.Patients.Where(c => c.Id == patient.id).FirstOrDefault();
            if (patientdetails != null)
            {
                patientdetails.FirstName = patient?.firstName;
                patientdetails.LastName = patient?.lastName;
                patientdetails.AddressLine1 = patient?.addressLine1;
                patientdetails.AddressLine2 = patient?.addressLine2;
                patientdetails.City = patient?.city;
                patientdetails.State = patient?.state;
                patientdetails.ZipCode = patient?.zipCode;
                patientdetails.Email = patient?.email;
                patientdetails.Phone = patient?.phone;
                _context.Patients.Update(patientdetails);
                _context.SaveChangesAsync();
            }
        }

        public void DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
    }
}
