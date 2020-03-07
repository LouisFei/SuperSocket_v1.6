using System;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// String type request information
    /// 如果你在 SuperSocket 中使用命令行协议，
    /// 所有接收到的数据将会翻译成 StringRequestInfo 实例。
    /// </summary>
    public class StringRequestInfo : RequestInfo<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringRequestInfo"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="body">The body.</param>
        /// <param name="parameters">The parameters.</param>
        public StringRequestInfo(string key, string body, string[] parameters)
            : base(key, body)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public string[] Parameters { get; private set; }

        /// <summary>
        /// Gets the first param.
        /// </summary>
        /// <returns></returns>
        public string GetFirstParam()
        {
            if(Parameters.Length > 0)
                return Parameters[0];

            return string.Empty;
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> at the specified index.
        /// </summary>
        public string this[int index]
        {
            get { return Parameters[index]; }
        }
    }
}

/*
    内置的命令行协议
    https://docs.supersocket.net/v1-6/zh-CN/The-Built-in-Command-Line-Protocol

    什么是协议? 
    很多人会回答 "TCP" 或者 "UDP"。 
    但是构建一个网络应用程序, 仅仅知道是 TCP 还是 UDP 是远远不够的。 
    TCP 和 UDP 是传输层协议。仅仅定义了传输层协议是不能让网络的两端进行通信的。
    你需要定义你的应用层通信协议把你接收到的二进制数据转化成你程序能理解的请求。

    内置的命令行协议
    命令行协议是一种被广泛应用的协议。
    一些成熟的协议如 Telnet, SMTP, POP3 和 FTP 都是基于命令行协议的。 
    在SuperSocket 中， 如果你没有定义自己的协议，SuperSocket 将会使用命令行协议, 这会使这样的协议的开发变得很简单。

    命令行协议定义了每个请求必须以回车换行结尾 "\r\n"。

    如果你在 SuperSocket 中使用命令行协议，所有接收到的数据将会翻译成 StringRequestInfo 实例。

    由于 SuperSocket 中内置的命令行协议用空格来分割请求的Key和参，因此当客户端发送如下数据到服务器端时:
    "LOGIN kerry 123456" + NewLine

    SuperSocket 服务器将会收到一个 StringRequestInfo 实例，这个实例的属性为:
    Key: "LOGIN"
    Body: "kerry 123456";
    Parameters: ["kerry", "123456"]



 */
