using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;

namespace BussinessObject
{
    public class ConnectApache
    {
        public static IConnection getConnection()
        {
            Console.WriteLine("Connecting...");
            IConnectionFactory connectionFactory = new ConnectionFactory("tcp://localhost:61616");
            IConnection conn = connectionFactory.CreateConnection("admin", "admin");
            conn.Start();

            return conn;
        }
    }
}
