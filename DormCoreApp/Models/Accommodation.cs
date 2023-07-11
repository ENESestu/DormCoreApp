namespace DormCoreApp.Models
{
    public class Accomodation
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string IsDeleted { get; set; }

        public string DormName { get; set; }
        public int RoomNo { get; set; }
        public int UserId { get; set; }
    }
}
