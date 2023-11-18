namespace ToDoList.API.Utils
{
    public class SettingsOptions
    {
        public ConnectionStrings connectionstrings { get; set; }
        public Jwt jwt { get; set; }



        public class ConnectionStrings
        {
            public string toDoListConnection { get; set; }
        }

        public class Jwt
        {
            public string Secret { get; set; }
            public int ExpirationSeconds { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
        }
    }
}