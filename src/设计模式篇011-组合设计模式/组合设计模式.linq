<Query Kind="Program" />

void Main()
{
	/// <summary>1. 创建根节点</summary>
	var root = new Composite("CEO");
	root.DoSomething();
	// 创建一个树枝构建
	var branch = new Composite("Soft Manager");
	root.Add(branch);
	// 创建两个叶子结点
	var leaf = new Leaf("A");
	var leaf2 = new Leaf("B");
	
	branch.Add(leaf);
	branch.Add(leaf2);
	
	Display(root);
}


//通过递归遍历树
public static void Display(Composite root)
{
	foreach (var element in root.GetChildren())
	{
		if (element.GetType() == typeof(Leaf))
		{ //叶子节点
			element.DoSomething();
		}
		else{
			element.DoSomething();
			Display((Composite)element);
		}
	}
}

public abstract class Component
{
	// 个体和整体都具有的共享逻辑
	public virtual void DoSomething()
	{
		// 可以编写共同的逻辑
		"我是父类方法".Dump();
	}
}

/// <summary>树枝节点</summary>
public class Composite:Component
{
	private string _name;
	
	public Composite(string name)
	{
		_name = name;
	}

	public override void DoSomething()
	{
		$"我是树枝节点{_name}".Dump();
	}
	
	// 构件容器
	private List<Component> compList = new();
	
	// 增加一个叶子构件或树枝构件
	public void Add(Component comp){
		compList.Add(comp);
	}
	
	// 删除一个叶子构件或树枝构件
	public void Remove(Component comp){
		compList.Remove(comp);
	}
	
	// 获得分支下的所有叶子构件和树枝构建
	public List<Component> GetChildren(){
		return compList;
	}
}

/// <summary>树叶节点</summary>
public class Leaf:Component{
	private string _name;
	
	public Leaf(string name)
	{
		_name = name;
	}

	/// <summary>这边可以覆写子类的方法</summary>
	public override void DoSomething(){
		$"我是树叶{_name}".Dump();
	}
}