using Effortless.Net.Encryption;
namespace ToDoList.API.Utils
{
    public class ConnectionString : IConnectionString
    {
        private readonly IConfiguration _configuration;
        private byte[] key1 { get; } = new byte[]
            {
                0xC5, 0x60, 0x45, 0xC6, 0xB7, 0xC8, 0xEF, 0x64,
                0x19, 0xCE, 0x73, 0xF2, 0xFF, 0xEE, 0xF1, 0xB6,
                0xDB, 0x36, 0x72, 0x45, 0x40, 0x06, 0x01, 0x58,
                0x88, 0x49, 0x48, 0x53, 0x07, 0xF6, 0x0E, 0x4C
            };

        private byte[] iv1 { get; } = new byte[]
        {
            0x21, 0x79, 0xA8, 0x0D, 0x59, 0xDA, 0x6E, 0x4B,
            0xE4, 0xBB, 0xF8, 0x87, 0xF1, 0x9C, 0x4E, 0x22
        };

        public ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string getConnection()
        {
               var connection =  Strings.Decrypt(_configuration.GetConnectionString("toDoListConnection"), key1, iv1);
            return connection;

        }


    }
}
