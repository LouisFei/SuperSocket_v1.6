using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.Facility.Protocol;

namespace CommonFormatProtocolDemo
{
    class MyBeginEndMarkReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { (byte)'!' };
        private readonly static byte[] EndMark = new byte[] { (byte)'$' };

        private readonly Encoding m_Encoding;
        private readonly char m_Spliter;

        public MyBeginEndMarkReceiveFilter()
            : this((byte)'#', Encoding.ASCII)
        {

        }

        public MyBeginEndMarkReceiveFilter(byte spliter, Encoding encoding)
            : base(BeginMark, EndMark) //传入开始标记和结束标记
        {
            this.m_Encoding = encoding;
            this.m_Spliter = (char)spliter;
        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            //TODO: 通过解析到的数据来构造请求实例，并返回
            var body = m_Encoding.GetString(readBuffer, offset + 1, length - 2);
            var array = body.Split(m_Spliter);
            return new StringRequestInfo(array[0], body, array);
        }
    }

    /// <summary>
    /// 带起止符的协议
    /// 在这类协议的每个请求之中 都有固定的开始和结束标记。
    /// 例如, 我有个协议，它的所有消息都遵循这种格式 "!xxxxxxxxxxxxxx$"。
    /// 因此，在这种情况下， "!" 是开始标记， "$" 是结束标记
    /// </summary>
    public class BeginEndMarkReceiveServer : AppServer
    {
        public BeginEndMarkReceiveServer()
            : base(new DefaultReceiveFilterFactory<MyBeginEndMarkReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {

        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            session.Send("Welcome to SuperSocket BeginEndMarkReceive Server.");
        }
    }
}

/*
    https://docs.supersocket.net/v1-6/zh-CN/The-Built-in-Common-Format-Protocol-Implementation-Templates
    BeginEndMarkReceiveFilter - 带起止符的协议
    在这类协议的每个请求之中 都有固定的开始和结束标记。例如, 我有个协议，它的所有消息都遵循这种格式 "!xxxxxxxxxxxxxx$"。因此，在这种情况下， "!" 是开始标记， "$" 是结束标记，于是你的接受过滤器可以定义成这样:

    class MyReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { (byte)'!' };
        private readonly static byte[] EndMark = new byte[] { (byte)'$' };

        public MyReceiveFilter()
            : base(BeginMark, EndMark) //传入开始标记和结束标记
        {

        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            //TODO: 通过解析到的数据来构造请求实例，并返回
        }
    }
    然后在你的 AppServer 类中使用这个接受过滤器 (ReceiveFilter):

    public class MyAppServer : AppServer
    {
        public MyAppServer()
            : base(new DefaultReceiveFilterFactory<MyReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {

        }
    }
 */
