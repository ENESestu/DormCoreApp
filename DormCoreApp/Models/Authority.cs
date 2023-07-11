namespace DormCoreApp.Models
{
    public class Authority
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
