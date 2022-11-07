



using albertzhao;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var stu1 = new Student() { Name="张三",Age=11};
        var stu2 = new Student() { Name="李四",Age =15};
        var stu3 = new Student() { Name = "张三", Age = 11 };

        Console.WriteLine(stu1 == stu2);
        Console.WriteLine(stu1 == stu3);
        Console.WriteLine("==================");



        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        //var sc = new ServiceCollection();
        //{
        //    using var streamOut = File.OpenWrite("C:\\Users\\szdxz\\Desktop\\Repo\\1.txt");
        //    using var writer = new StreamWriter(streamOut);
        //    writer.WriteLine("hello");
        //} 
       
        //string s = File.ReadAllText("C:\\Users\\szdxz\\Desktop\\Repo\\1.txt");
        //Console.WriteLine(s);


        Console.ReadKey();
    }
}