using System;
using System.Text;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace CommonFormatProtocolDemo
{
    /// <summary>
    /// 你需要基于类FixedHeaderReceiveFilter实现你自己的接收过滤器.
    /// 传入父类构造函数的 6 表示头部的长度;
    /// 方法"GetBodyLengthFromHeader(...)" 应该根据接收到的头部返回请求体的长度;
    /// 方法 ResolveRequestInfo(....)" 应该根据你接收到的请求头部和请求体返回你的请求类型的实例.
    /// 然后你就可以使用接收或者自己定义的接收过滤器工厂来在 SuperSocket 中启用该协议.
    /// </summary>
    class MyFixedHeaderReceiveFilter : FixedHeaderReceiveFilter<StringRequestInfo>
    {
        public MyFixedHeaderReceiveFilter()
            : base(7)
        {

        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            //return (int)header[offset + 4] * 256 + (int)header[offset + 5];
            var strLen = Encoding.ASCII.GetString(header, offset + 5, 2);
            return int.Parse(strLen.TrimStart('0'));
        }

        protected override StringRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            //return new BinaryRequestInfo(Encoding.UTF8.GetString(header.Array, header.Offset, 4), bodyBuffer.CloneRange(offset, length));
            var body = Encoding.ASCII.GetString(bodyBuffer, offset, length);
            return new StringRequestInfo(Encoding.ASCII.GetString(header.Array, header.Offset, 5), body, new string[] { body });

        }
    }

    /// <summary>
    /// 头部格式固定并且包含内容长度的协议
    /// 这种协议将一个请求定义为两大部分, 
    /// 第一部分定义了包含第二部分长度等等基础信息. 我们通常称第一部分为头部.
    /// 例如, 我们有一个这样的协议: 头部包含 7 个字节, 前 5 个字节用于存储请求的名字, 
    /// 后两个字节用于代表请求体的长度:
    /// +-------+---+-------------------------------+
    /// |request| l |                               |
    /// | name  | e |    request body               |
    /// |  (5)  | n |                               |
    /// |       |(2)|                               |
    /// +-------+---+-------------------------------+
    /// </summary>
    public class FixedHeaderReceiveServer : AppServer
    {
        public FixedHeaderReceiveServer()
            : base(new DefaultReceiveFilterFactory<MyFixedHeaderReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {

        }

        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            session.Send("Welcome to SuperSocket FixedHeaderReceive Server.");
        }
    }
}

/*

 */
