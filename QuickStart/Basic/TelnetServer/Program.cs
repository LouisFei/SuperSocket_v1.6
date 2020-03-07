using System;
using SuperSocket.SocketBase;

namespace SuperSocket.QuickStart.TelnetServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            var appServer = new AppServer();

            int port = 2012;
            //Setup the appServer
            if (!appServer.Setup(port)) //Setup with listening port
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            //注册会话新建事件处理方法
            appServer.NewSessionConnected += new SessionHandler<AppSession>(appServer_NewSessionConnected);

            Console.WriteLine();

            //Try to start the appServer
            if (!appServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The telnet server (port={0}) started successfully, press key 'q' to stop it!", port);

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

        /// <summary>
        /// 在事件处理代码中发送欢迎信息给客户端
        /// </summary>
        /// <param name="session"></param>
        static void appServer_NewSessionConnected(AppSession session)
        {
            session.Send("Welcome to SuperSocket Telnet Server.");
        }
    }
}

/*
使用Telnet客户端进行测试

1、open a telnet client
2、type "telnet localhost 2012" ending with an "ENTER"
3、you will get the message "Welcome to SuperSocket Telnet Server" 
*/
