using System;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// Basic request info parser, which parse request info by separating.
    /// 基本的请求信息解析器，它通过分符号来解析请求信息。
    /// </summary>
    /// <remarks>
    /// 如果你想更深度的定义请求的格式, 你可以基于接口 IRequestInfoParser 来实现一个 RequestInfoParser 类, 
    /// 然后当实例化 CommandLineReceiveFilterFactory 时传入拟定一个 RequestInfoParser 实例。
    /// </remarks>
    public class BasicRequestInfoParser : IRequestInfoParser<StringRequestInfo>
    {
        private readonly string m_Spliter;
        private readonly string[] m_ParameterSpliters;

        private const string m_OneSpace = " ";

        /// <summary>
        /// The default singlegton instance
        /// </summary>
        public static readonly BasicRequestInfoParser DefaultInstance = new BasicRequestInfoParser();

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRequestInfoParser"/> class.
        /// </summary>
        public BasicRequestInfoParser()
            : this(m_OneSpace, m_OneSpace)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRequestInfoParser"/> class.
        /// </summary>
        /// <param name="spliter">The spliter between command name and command parameters.</param>
        /// <param name="parameterSpliter">The parameter spliter.</param>
        public BasicRequestInfoParser(string spliter, string parameterSpliter)
        {
            m_Spliter = spliter;
            m_ParameterSpliters = new string[] { parameterSpliter };
        }

        #region IRequestInfoParser<StringRequestInfo> Members

        /// <summary>
        /// Parses the request info.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public StringRequestInfo ParseRequestInfo(string source)
        {
            int pos = source.IndexOf(m_Spliter);

            string name = string.Empty;
            string param = string.Empty;

            if (pos > 0)
            {
                name = source.Substring(0, pos);
                param = source.Substring(pos + m_Spliter.Length);
            }
            else
            {
                name = source;
            }

            return new StringRequestInfo(name, param,
                param.Split(m_ParameterSpliters, StringSplitOptions.RemoveEmptyEntries));
        }

        #endregion
    }
}
