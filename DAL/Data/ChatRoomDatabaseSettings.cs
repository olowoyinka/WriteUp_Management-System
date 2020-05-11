namespace DAL.Data
{
    public class ChatRoomDatabaseSettings : IChatRoomDatabaseSettings
    {
        public string ChatRoomsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
     
    public interface IChatRoomDatabaseSettings
    {
        string ChatRoomsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}