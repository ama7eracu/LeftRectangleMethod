

var IER = 0;
Console.WriteLine("Введите a:");
var a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите b:");
var b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите n:");
var n = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите Eps");
var eps = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите hMin");
var hMin = Convert.ToDouble(Console.ReadLine());
if (b<=a)
{
    IER = 3;
    Console.WriteLine($"IER:{IER}");
}
else
{
    var startMethod = new LeftRectangleMethod.LeftRectangleMethod(n, a, b, eps, hMin);
}