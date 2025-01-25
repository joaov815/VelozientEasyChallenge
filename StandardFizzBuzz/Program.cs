using System.Text.Json;
using TwistedFizzBuzz;

var res = TwistedFizzBuzzHelper.FromRange(1, 100);

// Output the default Fizz-Buzz Problem from 1 to 100
Console.WriteLine(JsonSerializer.Serialize(res));
