using System;
using SuperSocket.SocketBase.Config;

namespace SuperSocket.QuickStart.TelnetServer_AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            var appServer = new TelnetServer();

            var serverConfig = new ServerConfig
            {
                Port = 2012 //set the listening port
            };

            //Setup the appServer
            if (!appServer.Setup(serverConfig))
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            //Try to start the appServer
            if (!appServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"The telnet server ({serverConfig.Port}) started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            //Stop the appServer
            appServer.Stop();

            Console.WriteLine("The server was stopped!");
        }
    }
}

/*
     实现你自己的AppSession和AppServer允许你根据你业务的需求来方便的扩展SuperSocket，
     你可以绑定session的连接和断开事件，服务器实例的启动和停止事件。

     你还可以在AppServer的Setup方法中读取你的自定义配置信息。
     总而言之，这些功能让你方便的创建一个你所需要的socket服务器成为可能。
 */
