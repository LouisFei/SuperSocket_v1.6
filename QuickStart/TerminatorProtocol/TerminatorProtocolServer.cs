using System;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket.QuickStart.TerminatorProtocol
{
    /// <summary>
    /// TerminatorProtocolServer
    /// Each request end with the terminator "##"
    /// ECHO Your message##
    /// </summary>
    public class TerminatorProtocolServer : AppServer
    {
        public TerminatorProtocolServer()
            : base(new TerminatorReceiveFilterFactory("##"))
        {
            //https://docs.supersocket.net/v1-6/zh-CN/The-Built-in-Common-Format-Protocol-Implementation-Templates
            //结束符协议

        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);

            session.Send("Welcome to SuperSocket Terminator Protocol Server.");
        }
    }
}
