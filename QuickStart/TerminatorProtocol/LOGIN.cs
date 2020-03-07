using System;

using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket.QuickStart.TerminatorProtocol
{
    public class LOGIN : StringCommandBase
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            //session.Send(requestInfo.Body);

            Console.WriteLine($"Key: {requestInfo.Key}");
            Console.WriteLine($"Body: {requestInfo.Body}");
            Console.WriteLine($"Parameters: {string.Join(", ", requestInfo.Parameters)}");

            session.Send("login successfully!");
        }
    }
}
