using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace SuperSocket.QuickStart.TelnetServer_AppSession
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            //如果你想使用你的AppSession作为会话，你必须修改你的AppServer来使用它
            var appServer = new AppServer<TelnetSession>();

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
