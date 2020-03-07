using System;
using System.Text;

using SuperSocket.SocketBase;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;

namespace CommonFormatProtocolDemo
{
    /// <summary>
    /// 如果你的每个请求都是有9个字符组成的字符串，如"KILL BILL", 
    /// 你应该做的事就是想如下代码这样实现一个接收过滤器(ReceiveFilter):
    /// </summary>
    public class MyFixedSizeReceiveFilter : FixedSizeReceiveFilter<StringRequestInfo>
    {
        private readonly Encoding m_Encoding;
        private readonly char m_Spliter;

        public MyFixedSizeReceiveFilter()
            : this((byte)'#', Encoding.ASCII, 8) //传入固定的请求大小
        {

        }

        public MyFixedSizeReceiveFilter(byte spliter, Encoding encoding, int size)
            : base(size)//传入固定的请求大小
        {
            this.m_Encoding = encoding;
            this.m_Spliter = (char)spliter;
        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] buffer, int offset, int length, bool toBeCopied)
        {
            //throw new System.NotImplementedException();

            //通过解析到的数据来构造请求实例，并返回
            byte[] data = new byte[this.Size];
            Buffer.BlockCopy(buffer, offset, data, 0, data.Length);
            var body = m_Encoding.GetString(data, 0, data.Length);
            var array = body.Split(m_Spliter);
            return new StringRequestInfo(array[0], body, array);
        }

    }

    /// <summary>
    /// 固定请求大小的协议
    /// 在这种协议之中, 所有请求的大小都是相同的。
    /// </summary>
    public class FixedSizeReceiveServer : AppServer
    {
        /// <summary>
        /// 在你的 AppServer 类中使用这个接受过滤器 (ReceiveFilter):
        /// </summary>
        public FixedSizeReceiveServer()
            : base(new DefaultReceiveFilterFactory<MyFixedSizeReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {

        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            session.Send("Welcome to SuperSocket FixedSizeReceive Server.");
        }
    }


}

/*
    https://docs.supersocket.net/v1-6/zh-CN/The-Built-in-Common-Format-Protocol-Implementation-Templates

    FixedSizeReceiveFilter - 固定请求大小的协议
    在这种协议之中, 所有请求的大小都是相同的。如果你的每个请求都是有9个字符组成的字符串，如"KILL BILL", 你应该做的事就是想如下代码这样实现一个接收过滤器(ReceiveFilter):

    class MyReceiveFilter : FixedSizeReceiveFilter<StringRequestInfo>
    {
        public MyReceiveFilter()
            : base(9) //传入固定的请求大小
        {

        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] buffer, int offset, int length, bool toBeCopied)
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
