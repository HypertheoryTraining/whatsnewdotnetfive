using System;

Console.WriteLine("Hello from .NET 5");
Console.Write("What is your name?: ");
var name = Console.ReadLine();
SayHi(name);
Console.Write("What is your age: ");
var age = int.Parse(Console.ReadLine());

var msg = CheckAge(age);
Console.WriteLine(msg);

//if(name == "Jeff" || name.Length > 3)
//{
//    Console.WriteLine("Cool Name");
//}

if(name is "Jeff" or { Length: > 3 })
{
    Console.WriteLine("Cool Name - with pattern matching");
}

static void SayHi(string message) => Console.WriteLine($"Hello, {message}");

static string CheckAge(int age) => age switch
{
    >= 21 => "Old Enough",
    < 0 => "Give me a break",
    _ => "Too Young"
};