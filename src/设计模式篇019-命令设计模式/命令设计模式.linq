<Query Kind="Program" />

void Main()
{
	var iAndWife = new IAndWife();
	var command = new ConcreteCommand(iAndWife);
	var invoker = new Invoker(command);
	
	invoker.InvokeExecute("乡村振兴");
}

/// <summary>Receiver</summary>
public sealed class IAndWife{
	/// <summary>相当于 Receiver 类型的 Action 方法</summary>
	public void Execute(string job){
		("夫妻两正在做"+job).Dump();
	}
}

/// <summary>ICommand</summary>
public abstract class Command{
	protected IAndWife _worker;
	
	protected Command(IAndWife worker){
		_worker = worker;
	}
	
	//该方法就是抽象命令对象Command的Execute方法
	public abstract void Execute(string job);
}

/// <summary>Command</summary>
public sealed class ConcreteCommand : Command
{
	public ConcreteCommand(IAndWife worker):base(worker)
	{
		
	}
	
	public override void Execute(string job)
	{
		this._worker.Execute(job);
	}
}

/// <summary>命令发布者/调用者 Invoker</summary>
public sealed class Invoker{
	private Command _command;
	
	public Invoker(Command command)
	{
		this._command = command;
	}
	
	public void InvokeExecute(string job){
		_command.Execute(job);
	}
}