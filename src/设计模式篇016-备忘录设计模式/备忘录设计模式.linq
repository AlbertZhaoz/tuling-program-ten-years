<Query Kind="Program">
  <NuGetReference>CloneExtensions</NuGetReference>
  <NuGetReference>CloneExtensionsEx</NuGetReference>
  <Namespace>CloneExtensions</Namespace>
</Query>

void Main()
{
	// 1.创建一系列联系方式
	var persons = new List<ContactPerson>(){
		new ContactPerson(){Name="Albert",Phone="123"},
		new ContactPerson(){Name="Jack",Phone="234"},
		new ContactPerson(){Name="Lucy",Phone="456"},
	};
	// 2. 创建备忘录管理者,可以不要
	// var masterMemento = new MasterMemento();
	// 3. 创建备忘录构建者
	var personBackInvoker = new PersonBackOriginator(persons);
	// 2. 如果有管理者，则直接赋值给管理者
	// masterMemento.MementoPerson = personBackInvoker.CreateMemento();
	var memento = personBackInvoker.CreateMemento();
	// 4. 移除一个人
	personBackInvoker.RemovePerson(1);
	personBackInvoker.ShowPersonList();
	
	"我是分割线，下面将进行人员的恢复".Dump();
	personBackInvoker.RestoreMemento(memento);
	personBackInvoker.ShowPersonList();
	
}

/// <summary>要备份的对象</summary>
public sealed class ContactPerson{
	public string Name { get; set; }
	public string Phone {get;set;}
}

/// <summary>备忘录对象，用于保存当前对象数据</summary>
public sealed class Memento{
	public List<ContactPerson> PersonListBack { get;private set; }
	
	public Memento(List<ContactPerson> personList)
	{
		// 这边必须要进行深克隆
		// 使用包：CloneExtensions
		PersonListBack = personList.GetClone();
	}
}

/// <summary>管理备忘录对象，可能不止一个备忘录对象，如果只有一个可以不需要</summary>
public sealed class MasterMemento{
	public Memento MementoPerson { get; set; }
}

/// <summary>备忘录发起人-发起备忘</summary>
public sealed class PersonBackOriginator{
	// 联系人列表-初始状态
	private List<ContactPerson> _personList;
	
	/// <summary>初始化备忘录-将需要备份的对象赋值给 personList</summary>
	public PersonBackOriginator(List<ContactPerson> personList){
		this._personList = personList;
	}
	
	/// <summary>首次备份</summary>
	public Memento CreateMemento(){
		return new Memento(_personList);
	}
	
	/// <summary>将备份路中数据还原到联系人列表中</summary>
	public void RestoreMemento(Memento memento){
		_personList = memento.PersonListBack;
	}
	
	public void ShowPersonList(){
		foreach (var element in _personList)
		{
			(element.Name+"---"+element.Phone).Dump();
		}
	}
	
	public void RemovePerson(int index){
		_personList.RemoveAt(index);
	}
}