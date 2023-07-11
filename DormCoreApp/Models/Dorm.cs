namespace DormCoreApp.Models
{
    public class Dorm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageFilePath { get; set; }
        public string IsDeleted { get; set; }
    }
}
