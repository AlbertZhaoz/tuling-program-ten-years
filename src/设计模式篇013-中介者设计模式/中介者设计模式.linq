<Query Kind="Program" />

void Main()
{
	//一个房东、一个租房者、一个中介机构
	MediatorStructure mediator = new MediatorStructure();

	//房主和租房者只需要知道中介机构即可
	HouseOwner houseOwner = new HouseOwner("房东布鲁斯", mediator);
	Tenant tenant = new Tenant("租客张三", mediator);

	//中介结构要知道房东和租房者的信息
	mediator.SetHouseOwner(houseOwner);
	mediator.SetTenant(tenant);

	mediator.Constract("听说你那里有三室的房子出租？",tenant);
	mediator.Constract("是的!请问你需要租吗?",houseOwner);
}

/// <summary>抽象的一个中介</summary>
public abstract class Mediator
{
	public abstract void Constract(string message,Person person);
}

/// <summary>抽象同事对象，维持了一个对抽象中介者类的引用</summary>
public abstract class Person{
	protected string name;
	protected Mediator mediator;
	
	public Person(string name,Mediator mediator){
		this.name = name;
		this.mediator = mediator;
	}
}

public class HouseOwner:Person{
	public HouseOwner(string name,Mediator mediator):base(name,mediator)
	{
		
	}
	
	public void Constract(string message){
		mediator.Constract(message,this);	
	}

	// 获取信息
	public void GetMessage(string message)
	{
		Console.WriteLine("房东姓名:" + name + ",从中介处获得来自租客的信息：" + message);
	}
}

/// <summary>
/// 具体同事类:租房者
/// </summary>
public class Tenant : Person
{

	public Tenant(string name, Mediator mediator) : base(name, mediator)
	{
	}

	// 先与中介者通信，通过中介者来间接完成与其他同事类的通信
	public void Constract(string message)
	{
		mediator.Constract(message, this);
	}

	// 获取信息
	public void GetMessage(string message)
	{
		Console.WriteLine("租房者姓名:" + name + ",从中介者获得房源信息：" + message);
	}
}

/// <summary>
/// 具体中介者对象
/// </summary>
public class MediatorStructure : Mediator
{
	//首先中介结构必须知道所有房主和租房者的信息
	private HouseOwner houseOwner;
	private Tenant tenant;

	public HouseOwner GetHouseOwner()
	{
		return houseOwner;
	}

	public void SetHouseOwner(HouseOwner houseOwner)
	{
		this.houseOwner = houseOwner;
	}

	public Tenant GetTenant()
	{
		return tenant;
	}

	public void SetTenant(Tenant tenant)
	{
		this.tenant = tenant;
	}

	public override void Constract(string message, Person person)
	{
		if (person == houseOwner)
		{
			//如果是房东，则租房者获得信息
			tenant.GetMessage(message);
		}
		else
		{
			//反之，则是房东获得信息
			houseOwner.GetMessage(message);
		}
	}
}