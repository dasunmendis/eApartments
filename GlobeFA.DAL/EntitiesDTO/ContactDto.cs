namespace GlobeFa.DAL.EntitiesDTO
{
    public partial class ContactDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
        public string ContactMobile { get; set; }
        public string ContactHome { get; set; }
        public string ContactCountryCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? PostalCode { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailWork { get; set; }
    }
}
