namespace Contacts.Model
{
    public class Contact
    {        
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public string Email { get; set; }        
        public string PhoneNumber { get; set; }        
        public Status Status { get; set; }
    }
    public enum Status
    {
        Active,
        Inactive
    }
}
