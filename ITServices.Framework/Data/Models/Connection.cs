namespace ITServices.Framework.Data.Models
{
    public class JSONConnection
    {
        public Connections Connections { get; set; }
    }

    public class Connections
    {
        public Development Development { get; set; }

        public Production Production { get; set; }
    }

    public class Development : Connection
    {
    }

    public class Production : Connection
    {
    }

    public class Connection
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string UserID { get; set; }

        public string Password { get; set; }
    }
}