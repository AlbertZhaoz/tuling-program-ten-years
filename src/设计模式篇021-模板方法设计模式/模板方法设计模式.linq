<Query Kind="Program" />

void Main()
{
	var concreteA = new ConcreteAClass();
	var concreteB = new ConcreteBClass();
	// 调用模板方法
	concreteA.TemplateMethod();
	concreteB.TemplateMethod();
}

public abstract class AbsClass{
	/// <summary>protected 受保护的，只能在继承/自身的子类实例中被使用</summary>
	protected abstract void DoSomething();
	protected abstract void DoAnything();
	public void TemplateMethod(){
		this.DoSomething();
		this.DoAnything();
	}
}

public class ConcreteAClass : AbsClass
{
	protected override void DoAnything()
	{
		"A do anything".Dump();
	}

	protected override void DoSomething()
	{
		"A do something".Dump();
	}
}

public class ConcreteBClass : AbsClass
{
	protected override void DoAnything()
	{
		"B do anything".Dump();
	}

	protected override void DoSomething()
	{
		"B do something".Dump();
	}
}