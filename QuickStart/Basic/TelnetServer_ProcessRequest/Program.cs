using System;
using System.Linq;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace TelnetServer_ProcessRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            var appServer = new AppServer();
            var ip = "127.0.0.1";
            var port = 2012;

            //Setup the appServer
            if (!appServer.Setup(ip, port)) //Setup with listening IP and port
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            //注册会话新建事件处理方法
            appServer.NewSessionConnected += new SessionHandler<AppSession>(appServer_NewSessionConnected);

            //注册请求处理方法
            appServer.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(appServer_NewRequestReceived);

            Console.WriteLine();

            //Try to start the appServer
            if (!appServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"The telnet server ({ip}:{port}) started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();
            //Stop the appServer
            appServer.Stop();
            
            Console.WriteLine("The telnet server was stopped!");
        }

        /// <summary>
        /// 实现请求处理
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        static void appServer_NewRequestReceived(AppSession session, StringRequestInfo requestInfo)
        {
            /*
                 requestInfo.Key        是请求的命令行用空格分隔开的第一部分
                 requestInfo.Parameters 是用空格分隔开的其余部分

                 比如：ADD 1 2
                 requestInfo.Key是ADD
                 requestInfo.Parameters是[1,2]
             */

            switch (requestInfo.Key.ToUpper())
            {
                case("ECHO"):
                    session.Send(requestInfo.Body);
                    break;

                case ("ADD"):
                    session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
                    break;

                case ("MULT"):

                    var result = 1;

                    foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
                    {
                        result *= factor;
                    }

                    session.Send(result.ToString());
                    break;
            }
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
