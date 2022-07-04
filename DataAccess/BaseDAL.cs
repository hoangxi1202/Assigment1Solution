using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BusinessObject;
namespace DataAccess
{
    public class BaseDAL
    {
        public StockDataProvider dataProvider { get; set; } = null;
        public SqlConnection connection = null;
        //
        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            dataProvider = new StockDataProvider(connectionString);
        }
        public string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            return config["ConnectionStrings:Database"];
        }
        public MemberObject GetAdminAccount()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            return new MemberObject
            {
                Email = config["AdminAccount:UserName"],
                Password = config["AdminAccount:Password"],
            };
        }
        public void CloseConnection() => dataProvider.CloseConnection(connection);
    }
}
