using Effortless.Net.Encryption;
namespace ToDoList.API.Utils
{
    public static class ConnectionString 
    {

        public static byte[] getKey()
        {
            byte[] key1 = new byte[]
           {
                0xC5, 0x60, 0x45, 0xC6, 0xB7, 0xC8, 0xEF, 0x64,
                0x19, 0xCE, 0x73, 0xF2, 0xFF, 0xEE, 0xF1, 0xB6,
                0xDB, 0x36, 0x72, 0x45, 0x40, 0x06, 0x01, 0x58,
                0x88, 0x49, 0x48, 0x53, 0x07, 0xF6, 0x0E, 0x4C
           };
            return key1;
        }
        public static byte[] getIV()
        {
             byte[] iv1  = new byte[]
        {
            0x21, 0x79, 0xA8, 0x0D, 0x59, 0xDA, 0x6E, 0x4B,
            0xE4, 0xBB, 0xF8, 0x87, 0xF1, 0x9C, 0x4E, 0x22
        };
            return iv1;
        }

        public static string getConnectionAppSettings()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            return configuration.GetConnectionString("toDoListConnection");
        }

        

        public static string getConnection()
        {
               var connection = Strings.Decrypt(getConnectionAppSettings(), getKey(), getIV());
            return connection;

        }


    }
}
