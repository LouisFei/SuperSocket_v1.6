using System;
using System.Configuration;
using System.Collections.Specialized;

namespace SuperSocket.SocketBase.Config
{
    /// <summary>
    /// The root configuration interface
    /// 根节点配置
    /// </summary>
    public partial interface IRootConfig
    {
        /// <summary>
        /// Gets the max working threads.
        /// 线程池最大工作线程数量
        /// </summary>
        int MaxWorkingThreads { get; }

        /// <summary>
        /// Gets the min working threads.
        /// 线程池最小工作线程数量
        /// </summary>
        int MinWorkingThreads { get; }

        /// <summary>
        /// Gets the max completion port threads.
        /// 线程池最大完成端口线程数量
        /// </summary>
        int MaxCompletionPortThreads { get; }

        /// <summary>
        /// Gets the min completion port threads.
        /// 线程池最小完成端口线程数量
        /// </summary>
        int MinCompletionPortThreads { get; }


        /// <summary>
        /// Gets a value indicating whether [disable performance data collector].
        /// 是否禁用性能数据采集
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable performance data collector]; otherwise, <c>false</c>.
        /// </value>
        bool DisablePerformanceDataCollector { get; }

        /// <summary>
        /// Gets the performance data collect interval, in seconds.
        /// 性能数据采集频率 (单位为秒, 默认值: 60)
        /// </summary>
        int PerformanceDataCollectInterval { get; }


        /// <summary>
        /// Gets the log factory name.
        /// 默认logFactory的名字, 所有可用的 log factories定义在子节点 "logFactories" 之中
        /// </summary>
        /// <value>
        /// The log factory.
        /// </value>
        string LogFactory { get; }


        /// <summary>
        /// Gets the isolation mode.
        /// 服务器实例隔离级别
        /// </summary>
        /// <remarks>
        /// None - 无隔离
        /// AppDomain - 应用程序域级别的隔离，多个服务器实例运行在各自独立的应用程序域之中
        /// Process - 进程级别的隔离，多个服务器实例运行在各自独立的进程之中
        /// </remarks>
        IsolationMode Isolation { get; }


        /// <summary>
        /// Gets the option elements.
        /// </summary>
        NameValueCollection OptionElements { get; }

        /// <summary>
        /// Gets the child config.
        /// </summary>
        /// <typeparam name="TConfig">The type of the config.</typeparam>
        /// <param name="childConfigName">Name of the child config.</param>
        /// <returns></returns>
        TConfig GetChildConfig<TConfig>(string childConfigName)
            where TConfig : ConfigurationElement, new();

        //整个程序的默认 thread culture，只在.Net 4.5中可用
        //defaultCulture
    }
}
