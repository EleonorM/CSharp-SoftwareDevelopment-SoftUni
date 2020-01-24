namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Routing;

    public class Launcher
    {
        public static void Main()
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeContoller().Index(request));
            //serverRoutingTable.Add(HttpRequestMethod.Get, "/login", request => new HomeContoller().Login(request));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
