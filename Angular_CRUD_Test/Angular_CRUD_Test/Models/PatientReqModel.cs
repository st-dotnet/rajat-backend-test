namespace Angular_CRUD_Test.Models
{
    public class PatientReqModel
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? addressLine1 { get; set; }
        public string? addressLine2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zipCode { get; set; }
    }
    public class Search
    {
        public string? searchByFirstName { get; set; }
    }
}
