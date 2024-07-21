Console.WriteLine("Zadatak 2");

var num1 = int.MaxValue;
var num2 = long.MaxValue;

try
{
    var result = checked(num1 + num2); // Check for overflow
    Console.WriteLine($"{num1} + {num2} = {result}");
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message);
}