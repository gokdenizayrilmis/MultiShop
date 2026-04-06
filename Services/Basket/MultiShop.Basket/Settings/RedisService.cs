using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }
        private ConnectionMultiplexer _connectionMultiplexer { get; set; }
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect()=> _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1)
        {
            if (_connectionMultiplexer == null || !_connectionMultiplexer.IsConnected)
            {
                Connect();
            }

            return _connectionMultiplexer.GetDatabase(db); //DB yerine 0 olabilir?
        }



    }
}
