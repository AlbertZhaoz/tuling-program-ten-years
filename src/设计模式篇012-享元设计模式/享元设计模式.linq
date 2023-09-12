<Query Kind="Program" />

void Main()
{
	BikeFactory bF = new();
	var bikeWeight = bF.GetBike();
	bikeWeight.Ride("albert");
	// 如果归还的话，第二个人用的还是自行车 0
	bikeWeight.Back("albert");
	var bikeWeight2 = bF.GetBike();
	bikeWeight2.Ride("Lucy");
	var bikeWeight3 = bF.GetBike();
	bikeWeight3.Ride("Jack");
	
}


public abstract class FlyWeightBike{
	// 内部状态：不受外界环境影响而发生变化
	// BikeID  State(0 锁定 1 骑行）  
	public string BikeId { get; set; }
	public int State {get;set;}
	// 外部状态：用户--骑行、归还
	public abstract void Ride(string userName);
	public abstract void Back(string userName);
}

public class YellowBike : FlyWeightBike
{
	public YellowBike(string id)
	{
		this.BikeId = id;
	}

	public override void Ride(string userName)
	{
		this.State = 1;
		$"用户{userName}正在骑行{this.BikeId}的自行车".Dump();
	}

	public override void Back(string userName)
	{
		this.State = 0;
		$"用户{userName}归还了{this.BikeId}的自行车".Dump();
	}	
}

public class BikeFactory
{
	List<FlyWeightBike> bikePool = new();
	
	public BikeFactory()
	{
		for (int i = 0; i < 3; i++)
		{
			bikePool.Add(new YellowBike(i.ToString()));
		}
	}
	
	public FlyWeightBike GetBike(){
		return bikePool.FirstOrDefault(p => p.State == 0);
	}
}