using System;
using System.Linq;

using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket.QuickStart.TelnetServer_AppServer
{
    public class LOGIN : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            //session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());

            Console.WriteLine($"Key: {requestInfo.Key}");
            Console.WriteLine($"Body: {requestInfo.Body}");
            Console.WriteLine($"Parameters: {string.Join(", ", requestInfo.Parameters)}");

            session.Send("login successfully!");

        }
    }
}
