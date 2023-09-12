<Query Kind="Program" />

void Main()
{
	var requestDao = new PurchaseRequest(500,"一把大刀");
	var requestHuaJi = new PurchaseRequest(2000,"方天画戟");
	var requestJian = new PurchaseRequest(8000,"村好剑");

	Approver manager = new Manager("部门老大消炎");
	Approver financial = new FinancialManager("财务总监琳儿");
	Approver ceo = new CEO("CEO美杜莎");
	
	// 设置责任链
	manager.NextApprover = financial;
	financial.NextApprover = ceo;
	
	// 处理请求
	manager.ProcessRequest(requestDao);
	manager.ProcessRequest(requestHuaJi);
	manager.ProcessRequest(requestJian);
}

/// <summary>采购请求</summary>
public sealed class PurchaseRequest{
	/// <summary>金额</summary>
	public double Amount {get;set;}
	/// <summary>产品名字</summary>
	public string ProductName { get; set; }
	public PurchaseRequest(double amount,string productName)
	{
		this.Amount = amount;
		this.ProductName = productName;
	}
}

/// <summary>抽象审批人</summary>
public abstract class Approver{
	/// <summary>下一位审批人</summary>
	public Approver NextApprover { get; set; }
	/// <summary>审批人姓名</summary>
	public string Name { get; set; }
	
	public Approver(string name)
	{
		this.Name = name;
	}
	
	/// <summary>处理请求</summary>
	public abstract void ProcessRequest(PurchaseRequest request);
}

/// <summary>部门经理</summary>
public sealed class Manager : Approver
{
	public Manager(string name):base(name)
	{
		
	}
	
	public override void ProcessRequest(PurchaseRequest request)
	{
		if(request.Amount <=1000){
			(this.Name+"---部门经理批准了对原材料的采购计划！"+request.ProductName).Dump();
		}
		else if(NextApprover != null){
			NextApprover.ProcessRequest(request);
		}
		else{
			"下一个处理者为空".Dump();
		}
	}
}

/// <summary>部门经理</summary>
public sealed class FinancialManager : Approver
{
	public FinancialManager(string name) : base(name)
	{

	}

	public override void ProcessRequest(PurchaseRequest request)
	{
		if (request.Amount>1000&&request.Amount <= 5000)
		{
			( this.Name + "---财务经理批准了对原材料的采购计划！" +request.ProductName).Dump();
		}
		else if (NextApprover != null)
		{
			NextApprover.ProcessRequest(request);
		}
		else
		{
			"下一个处理者为空".Dump();
		}
	}
}

/// <summary>总裁</summary>
public sealed class CEO : Approver
{
	public CEO(string name) : base(name)
	{

	}

	public override void ProcessRequest(PurchaseRequest request)
	{
		if (request.Amount > 5000)
		{
			(this.Name + "---总经理批准了对原材料的采购计划！" + request.ProductName).Dump();
		}
		else
		{
			"最高级别者，下面无人了".Dump();
		}
	}
}

