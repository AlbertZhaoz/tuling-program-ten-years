<Query Kind="Program" />

void Main()
{
	var context = new Context();
	// 设置初始运行状态
	context.SetState(new CloseState());
	context.Open();
	context.Close();
	context.Stop();
	context.Run();
}

public abstract class State{
	// 定义一个环境上下文，状态的变化引起的功能变化
	protected Context _context;
	public void SetContext(Context context)
	{
		_context = context;
	}
	//首先电梯门开启动作
	public abstract void Open();
	//电梯门有开启，那当然也就有关闭了
	public abstract void Close();
	//电梯要能上能下，运行起来
	public abstract void Run();
	//电梯还要能停下来
	public abstract void Stop();
}

public class Context{
	// 定义出所有电梯状态
	public static readonly OpenState OpenState = new OpenState();
	public static readonly CloseState CloseState = new CloseState();
	public static readonly RunState RunState = new RunState();
	public static readonly StopState StopState = new StopState();
	
	// 定义电梯当前状态
	State _state;
	
	public State State
	{
		get { return _state; }
		set { _state = value; }
	}
	
	/// <summary>设置电梯状态</summary>
	public void SetState(State State){
		_state = State;
		// 把当前的环境设置到所有的状态实现内中
		_state.SetContext(this);
	}
	
	public void Open(){
		_state.Open();
	}

	public void Close()
	{
		_state.Close();
	}

	public void Run()
	{
		_state.Run();
	}

	public void Stop()
	{
		_state.Stop();
	}
}

public class OpenState : State
{
	// 开启之后可以关门
	public override void Close()
	{
		// 状态修改为关闭状态
		this._context.SetState(Context.CloseState);
		this._context.Close();
	}

	public override void Open()
	{
		"电梯门开启".Dump();
	}

	/// <summary>开启不可以运行</summary>
	public override void Run()
	{
		
	}
	/// <summary>开启不可以急停</summary>
	public override void Stop()
	{
		
	}
}

public class CloseState : State
{
	public override void Close()
	{
		"电梯关门".Dump();
	}

	public override void Open()
	{
		// 切换到开门状态
		this._context.SetState(Context.OpenState);
		this._context.State.Open();
	}

	public override void Run()
	{
		this._context.SetState(Context.OpenState);
		this._context.Open();
	}

	public override void Stop()
	{
		this._context.SetState(Context.StopState);
		this._context.Stop();
	}
}

public class RunState : State
{
	public override void Close()
	{
		
	}

	public override void Open()
	{
		
	}

	public override void Run()
	{
		"电梯运行中".Dump();
	}

	public override void Stop()
	{
		this._context.SetState(Context.StopState);
		this._context.Stop();
	}
}

public class StopState : State
{
	public override void Close()
	{
		
	}

	public override void Open()
	{
		// 切换到开门状态
		this._context.SetState(Context.OpenState);
		this._context.State.Open();
	}

	public override void Run()
	{
		this._context.SetState(Context.OpenState);
		this._context.Open();
	}

	public override void Stop()
	{
		"电梯已停止".Dump();
	}
}