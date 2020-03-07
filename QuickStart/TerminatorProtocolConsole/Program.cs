using System;

using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;

namespace TerminatorProtocolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IBootstrap bootstrap = BootstrapFactory.CreateBootstrapFromConfigFile("SuperSocket.config");
            if (!bootstrap.Initialize())
            {
                Console.WriteLine("Failed to initialize!");
                Console.ReadKey();
                return;
            }

            var result = bootstrap.Start();

            //Console.WriteLine("Start result: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            //foreach (var s in bootstrap.AppServers)
            //{
            //    Console.WriteLine($"{s.Config.Ip}:{s.Config.Port}");
            //}
            //Console.WriteLine("Press key 'q' to stop it!");

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
