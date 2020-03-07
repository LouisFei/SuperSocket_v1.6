using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;

namespace SuperSocket.SocketBase.Config
{
    /// <summary>
    /// Server instance configuation interface
    /// 服务器实例配置
    /// </summary>
    public partial interface IServerConfig
    {
        /// <summary>
        /// Gets the name of the server type this appServer want to use.
        /// </summary>
        /// <value>
        /// The name of the server type.
        /// 所选用的服务器类型在 serverTypes 节点的名字，
        /// 配置节点 serverTypes 用于定义所有可用的服务器类型，
        /// </value>
        string ServerTypeName { get; }

        /// <summary>
        /// Gets the type definition of the appserver.
        /// 服务器实例的类型的完整名称
        /// </summary>
        /// <value>
        /// The type of the server.
        /// </value>
        string ServerType { get; }

        /// <summary>
        /// Gets the Receive filter factory.
        /// 定义该实例所使用的接收过滤器工厂的名字
        /// </summary>
        string ReceiveFilterFactory { get; }

        /// <summary>
        /// Gets the ip.
        /// 服务器监听的ip地址。
        /// 你可以设置具体的地址，也可以设置为下面的值 
        /// Any - 所有的IPv4地址 
        /// IPv6Any - 所有的IPv6地址
        /// </summary>
        string Ip { get; }

        /// <summary>
        /// Gets the port.
        /// 服务器监听的端口
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Gets the options.
        /// </summary>
        NameValueCollection Options { get; }


        /// <summary>
        /// Gets the option elements.
        /// </summary>
        NameValueCollection OptionElements { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IServerConfig"/> is disabled.
        /// 服务器实例是否禁用了
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        bool Disabled { get; }

        /// <summary>
        /// Gets the name.
        /// 服务器实例的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the mode.
        /// Socket服务器运行的模式, Tcp (默认) 或者 Udp
        /// </summary>
        SocketMode Mode { get; }

        /// <summary>
        /// Gets the send time out.
        /// 发送数据超时时间
        /// </summary>
        int SendTimeOut { get; }

        /// <summary>
        /// Gets the max connection number.
        /// 可允许连接的最大连接数
        /// </summary>
        int MaxConnectionNumber { get; }

        /// <summary>
        /// Gets the size of the receive buffer.
        /// 接收缓冲区大小
        /// </summary>
        /// <value>
        /// The size of the receive buffer.
        /// </value>
        int ReceiveBufferSize { get; }

        /// <summary>
        /// Gets the size of the send buffer.
        /// 发送缓冲区大小
        /// </summary>
        /// <value>
        /// The size of the send buffer.
        /// </value>
        int SendBufferSize { get; }


        /// <summary>
        /// Gets a value indicating whether sending is in synchronous mode.
        /// 是否启用同步发送模式, 默认值: false
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sync send]; otherwise, <c>false</c>.
        /// </value>
        bool SyncSend { get; }

        /// <summary>
        /// Gets a value indicating whether log command in log file.
        /// 是否记录命令执行的记录
        /// </summary>
        /// <value><c>true</c> if log command; otherwise, <c>false</c>.</value>
        bool LogCommand { get; }

        /// <summary>
        /// Gets a value indicating whether clear idle session.
        /// true 或 false, 是否定时清空空闲会话，默认值是 false
        /// </summary>
        /// <value><c>true</c> if clear idle session; otherwise, <c>false</c>.</value>
        bool ClearIdleSession { get; }

        /// <summary>
        /// Gets the clear idle session interval, in seconds.
        /// 清空空闲会话的时间间隔, 默认值是120, 单位为秒;
        /// </summary>
        /// <value>The clear idle session interval.</value>
        int ClearIdleSessionInterval { get; }


        /// <summary>
        /// Gets the idle session timeout time length, in seconds.
        /// 会话空闲超时时间; 
        /// 当此会话空闲时间超过此值，同时clearIdleSession被配置成true时，
        /// 此会话将会被关闭; 默认值为300，单位为秒;
        /// </summary>
        /// <value>The idle session time out.</value>
        int IdleSessionTimeOut { get; }

        /// <summary>
        /// Gets X509Certificate configuration.
        /// 这各节点用于定义用于此服务器实例的X509Certificate证书的信息
        /// </summary>
        /// <value>X509Certificate configuration.</value>
        ICertificateConfig Certificate { get; }


        /// <summary>
        /// Gets the security protocol, X509 certificate.
        /// Empty, Tls, Ssl3. Socket服务器所采用的传输层加密协议，默认值为空;
        /// </summary>
        string Security { get; }


        /// <summary>
        /// Gets the length of the max request.
        /// 最大允许的请求长度，默认值为1024;
        /// </summary>
        /// <value>
        /// The length of the max request.
        /// </value>
        int MaxRequestLength { get; }


        /// <summary>
        /// Gets a value indicating whether [disable session snapshot].
        /// 是否禁用会话快照, 默认值为 false.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable session snapshot]; otherwise, <c>false</c>.
        /// </value>
        bool DisableSessionSnapshot { get; }
        /// <summary>
        /// Gets the interval to taking snapshot for all live sessions.
        /// 会话快照时间间隔, 默认值是 5, 单位为秒;
        /// </summary>
        int SessionSnapshotInterval { get; }

        /// <summary>
        /// Gets the connection filters used by this server instance.
        /// 定义该实例所使用的连接过滤器的名字，多个过滤器用 ',' 或者 ';' 分割开来。 
        /// 可用的连接过滤器定义在根节点的一个子节点内，将会在下面的文档中做更多介绍;
        /// </summary>
        /// <value>
        /// The connection filter's name list, seperated by comma
        /// </value>
        string ConnectionFilter { get; }

        /// <summary>
        /// Gets the command loader, multiple values should be separated by comma.
        /// 定义该实例所使用的命令加载器的名字，多个过滤器用 ',' 或者 ';' 分割开来。 
        /// 可用的命令加载器定义在根节点的一个子节点内，将会在下面的文档中做更多介绍;
        /// </summary>
        string CommandLoader { get; }

        /// <summary>
        /// Gets the start keep alive time, in seconds
        /// 网络连接正常情况下的keep alive数据的发送间隔, 默认值为 600, 单位为秒;
        /// </summary>
        int KeepAliveTime { get; }


        /// <summary>
        /// Gets the keep alive interval, in seconds.
        /// Keep alive失败之后, keep alive探测包的发送间隔，默认值为 60, 单位为秒;
        /// </summary>
        int KeepAliveInterval { get; }


        /// <summary>
        /// Gets the backlog size of socket listening.
        /// 监听队列的大小
        /// </summary>
        int ListenBacklog { get; }


        /// <summary>
        /// Gets the startup order of the server instance.
        /// 服务器实例启动顺序, 
        /// bootstrap 将按照此值的顺序来启动多个服务器实例
        /// </summary>
        int StartupOrder { get; }


        /// <summary>
        /// Gets the child config.
        /// </summary>
        /// <typeparam name="TConfig">The type of the config.</typeparam>
        /// <param name="childConfigName">Name of the child config.</param>
        /// <returns></returns>
        TConfig GetChildConfig<TConfig>(string childConfigName)
            where TConfig : ConfigurationElement, new();


        /// <summary>
        /// Gets the listeners' configuration.
        /// 此配置节点用于支持一个服务器实例监听多个IP/端口组合。 
        /// 此配置节点应该包含一个或者多个拥有一下属性的listener节点:
        /// </summary>
        IEnumerable<IListenerConfig> Listeners { get; }

        /// <summary>
        /// Gets the log factory name.
        /// 定义该实例所使用的日志工厂(LogFactory)的名字。 
        /// 可用的日志工厂(LogFactory)定义在根节点的一个子节点内，将会在下面的文档中做更多介绍; 
        /// 如果你不设置该属性，定义在根节点的日志工厂(LogFactory)将会被使用，
        /// 如果根节点也未定义日志工厂(LogFactory)，该实例将会使用内置的 log4net 日志工厂(LogFactory);
        /// </summary>
        string LogFactory { get; }


        /// <summary>
        /// Gets the size of the sending queue.
        /// 发送队列最大长度, 默认值为5
        /// </summary>
        /// <value>
        /// The size of the sending queue.
        /// </value>
        int SendingQueueSize { get; }



        /// <summary>
        /// Gets a value indicating whether [log basic session activity like connected and disconnected].
        /// 是否记录session的基本活动，如连接和断开
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [log basic session activity]; otherwise, <c>false</c>.
        /// </value>
        bool LogBasicSessionActivity { get; }


        /// <summary>
        /// Gets a value indicating whether [log all socket exception].
        /// </summary>
        /// <value>
        /// <c>true</c> if [log all socket exception]; otherwise, <c>false</c>.
        /// </value>
        bool LogAllSocketException { get; }


        /// <summary>
        /// Gets the default text encoding.
        /// 文本的默认编码，默认值是 ASCII;
        /// </summary>
        /// <value>
        /// The text encoding.
        /// </value>
        string TextEncoding { get; }


        /// <summary>
        /// Gets the command assemblies configuration.
        /// </summary>
        /// <value>
        /// The command assemblies.
        /// </value>
        IEnumerable<ICommandAssemblyConfig> CommandAssemblies { get; }

        //此服务器实例的默认 thread culture, 只在.Net 4.5中可用而且在隔离级别为 'None' 时无效;
        //defaultCulture
    }
}
