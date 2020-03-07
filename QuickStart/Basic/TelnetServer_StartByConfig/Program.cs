using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;

namespace SuperSocket.QuickStart.TelnetServer_StartByConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            //通过配置启动SuperSocket
            var bootstrap = BootstrapFactory.CreateBootstrap();

            if (!bootstrap.Initialize())
            {
                Console.WriteLine("Failed to initialize!");
                Console.ReadKey();
                return;
            }

            var result = bootstrap.Start();

            Console.WriteLine("Start result: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            foreach (var s in bootstrap.AppServers)
            {
                Console.WriteLine($"{s.Config.Ip}:{s.Config.Port}");
            }
            Console.WriteLine("Press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            //Stop the appServer
            bootstrap.Stop();

            Console.WriteLine("The server was stopped!");
        }
    }
}

/*
    为什么要通过配置启动？
    1、避免硬编码
    2、SuperSocket提供了很多有用的配置选项
    3、可以充分利用SuperSocket提供的工具

    如何使用Bootstrap来通过配置启动SuperSocket
        SuperSocket配置section SuperSocket使用.NET自带的配置技术，SuperSocket有一个专门的配置Section:
        <configSections>
            <section name="superSocket"
                 type="SuperSocket.SocketEngine.Configuration.SocketServiceConfig, SuperSocket.SocketEngine" />
        </configSections>

    Server实例的配置
    <superSocket>
        <servers>
          <server name="TelnetServer"
              serverType="SuperSocket.QuickStart.TelnetServer_StartByConfig.TelnetServer, SuperSocket.QuickStart.TelnetServer_StartByConfig"
              ip="Any" port="2020">
          </server>
        </servers>
    </superSocket>
    现在，我在这里解释配置的服务器节点：
        name: 实例名称
        serverType: 实例运行的AppServer类型
        ip: 侦听ip
        port: 侦听端口

    更多参考：https://docs.supersocket.net/v1-6/zh-CN/Start-SuperSocket-by-Configuration
 */
