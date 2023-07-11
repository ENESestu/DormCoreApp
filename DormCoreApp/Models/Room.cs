namespace DormCoreApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }
        public int Story { get; set; }
        public string IsDeleted { get; set; }

        public int DormId { get; set; }
    }
}
