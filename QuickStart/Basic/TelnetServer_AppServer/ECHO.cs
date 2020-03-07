using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket.QuickStart.TelnetServer_AppServer
{
    /// <summary>
    /// 如果你在你的系统中使用你自己建立的AppSession类，
    /// 那么你必须将你自己定义的AppSession类传进去，否则你的服务器无法发现这个Command。
    /// </summary>
    public class ECHO : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body);
        }
    }
}
