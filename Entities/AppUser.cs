namespace BuisnessReBOT.Entities
{
    public class AppUser:BaseEntity
    {
        public long ChatId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
