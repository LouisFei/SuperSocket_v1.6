# SuperSocket  [![Build Status](https://travis-ci.org/kerryjiang/SuperSocket.svg?branch=v1.6)](https://travis-ci.org/kerryjiang/SuperSocket)


**SuperSocket** is a light weight extensible socket application framework.
You can use it to build a server side socket application easily without thinking about how to use socket, how to maintain the socket connections and how socket works.

It is a pure C# project which is designed to be extended, so it is easy to be integrated to your existing system.
As long as your systems are developed in .NET language,
you must be able to use SuperSocket to build your socket application as a part of your current system perfectly.


- **Project homepage**:		[http://www.supersocket.net/](http://www.supersocket.net/)
- **Documentation**:		[http://docs.supersocket.net/](http://docs.supersocket.net/)
- **Releases download**:	[http://supersocket.codeplex.com/releases/](http://supersocket.codeplex.com/releases/)
- **License**: 				[http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0)


**NuGet Packages**

| Name                      | Package                           |
|---------------------------|-----------------------------------|
| **SuperSocket** 			    | [![SuperSocket][1]][2]      |
| **SuperSocket.Engine** 	  | [![SuperSocket.Engine][3]][4]   |
| **SuperSocket.WebSocket** | [![SuperSocket.WebSocket][5]][6]	|


[1]: https://img.shields.io/nuget/v/SuperSocket.svg?style=flat
[2]: https://www.nuget.org/packages/SuperSocket
[3]: https://img.shields.io/nuget/v/SuperSocket.Engine.svg?style=flat
[4]: https://www.nuget.org/packages/SuperSocket.Engine
[5]: https://img.shields.io/nuget/v/SuperSocket.WebSocket.svg?style=flat
[6]: https://www.nuget.org/packages/SuperSocket.WebSocket

# 架构设计示意图
## SuperSocket 层次示意图
![SuperSocket层次示意图_layermodel](doc/layermodel.jpg)
## SuperSocket 对象模型图示意图
![SuperSocket 对象模型图示意图](doc/objectmodel.jpg)
## SuperSocket 请求处理模型示意图
![SuperSocket 请求处理模型示意图_requesthandlingmodel](doc/requesthandlingmodel.jpg)
## SuperSocket 隔离模型示意图
![SuperSocket 隔离模型示意图](doc/isolationmodel.jpg)


*Copyright 2010-2015 Kerry Jiang (kerry-jiang@hotmail.com)*
