<Query Kind="Program">
  <NuGetReference Version="2.0.0-beta.173">TouchSocket</NuGetReference>
  <Namespace>TouchSocket.Core</Namespace>
  <Namespace>TouchSocket.Sockets</Namespace>
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

void Main()
{
	CreateSimpleSocket();
	Console.ReadLine();
}

// 以下代码版本请安装 preview 版本
public void CreateSimpleSocket()
{
	TcpService service = new TcpService();
	service.Connecting = (client, e) => { };//有客户端正在连接
	service.Connected = (client, e) => { };//有客户端成功连接
	service.Disconnecting = (client, e) => { };//有客户端正在断开连接，只有当主动断开时才有效。
	service.Disconnected = (client, e) => { };//有客户端断开连接
	service.Received = (client, byteBlock, requestInfo) =>
	{
		//从客户端收到信息
		string mes = Encoding.UTF8.GetString(byteBlock.Buffer, 0, byteBlock.Len);//注意：数据长度是byteBlock.Len
		client.Logger.Info($"已从{client.Id}接收到信息：{mes}");

		client.Send(mes);//将收到的信息直接返回给发送方

		//client.Send("id",mes);//将收到的信息返回给特定ID的客户端
		// 这边做了一个小广播功能
		var ids = service.GetIds();
		foreach (var clientId in ids)//将收到的信息返回给在线的所有客户端。
		{
			if (clientId != client.Id)//不给自己发
			{
				service.Send(clientId, mes);
			}
		}
	};

	service.Setup(new TouchSocketConfig()//载入配置
		.SetListenIPHosts("tcp://127.0.0.1:7000", 7001)//同时监听两个地址
		.ConfigureContainer(a =>//容器的配置顺序应该在最前面
		{
			a.AddConsoleLogger();//添加一个控制台日志注入（注意：在maui中控制台日志不可用）
		})
		.ConfigurePlugins(a =>
		{
			//a.Add();//此处可以添加插件
		}))
		.Start();//启动
}