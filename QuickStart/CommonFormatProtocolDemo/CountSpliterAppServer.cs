using SuperSocket.SocketBase;
using SuperSocket.Facility.Protocol;

namespace CommonFormatProtocolDemo
{
    /// <summary>
    /// 固定数量分隔符协议
    /// 有些协议定义了像这样格式的请求 "#part1#part2#part3#part4#part5#part6#part7#". 
    /// 每个请求有7个由 '#' 分隔的部分.
    /// </summary>
    public class CountSpliterAppServer : AppServer
    {
        public CountSpliterAppServer()
            : base(new CountSpliterReceiveFilterFactory((byte)'#', 8)) // 7 parts but 8 separators
        {

        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            session.Send("Welcome to SuperSocket CountSpliter Server.");
        }
    }
}

/*
    你也可以使用下面的类更深入的定制这种协议:

    CountSpliterReceiveFilter<TRequestInfo>
    CountSpliterReceiveFilterFactory<TReceiveFilter>
    CountSpliterReceiveFilterFactory<TReceiveFilter, TRequestInfo>
 */
