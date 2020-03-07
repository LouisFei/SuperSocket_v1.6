using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace SuperSocket.QuickStart.TelnetServer_AppServer
{
    /// <summary>
    /// AppServer 代表了监听客户端连接，承载TCP连接的服务器实例。
    /// 理想情况下，我们可以通过AppServer实例获取任何你想要的客户端连接，
    /// 服务器级别的操作和逻辑应该定义在此类之中。
    /// 如果你想使用你的AppSession作为会话，你必须修改你的AppServer来使用它
    /// </summary>
    public class TelnetServer : AppServer<TelnetSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }
}
