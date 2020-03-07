using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace CommonFormatProtocolDemo
{
    /// <summary>
    /// TerminatorReceiveFilter - 结束符协议
    /// 与命令行协议类似，一些协议用结束符来确定一个请求.
    /// 例如, 一个协议使用两个字符 "##" 作为结束符, 于是你可以使用类 "TerminatorReceiveFilterFactory":
    /// </summary>
    public class TerminatorProtocolServer : AppServer
    {
        public TerminatorProtocolServer()
            : base(new TerminatorReceiveFilterFactory("##"))
        {

        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            session.Send("Welcome to SuperSocket Terminator Protocol Server.");
        }
    }
}

/*
    https://docs.supersocket.net/v1-6/zh-CN/The-Built-in-Common-Format-Protocol-Implementation-Templates
    默认的请求类型是 StringRequestInfo, 你也可以创建自己的请求类型, 不过这样需要你做一点额外的工作:

    基于TerminatorReceiveFilter实现你的接收过滤器(ReceiveFilter):

    public class YourReceiveFilter : TerminatorReceiveFilter<YourRequestInfo>
    {
        //More code
    }
    实现你的接收过滤器工厂(ReceiveFilterFactory)用于创建接受过滤器实例:

    public class YourReceiveFilterFactory : IReceiveFilterFactory<YourRequestInfo>
    {
        //More code
    }
    然后在你的 AppServer 中使用这个接收过滤器工厂(ReceiveFilterFactory). 
*/
