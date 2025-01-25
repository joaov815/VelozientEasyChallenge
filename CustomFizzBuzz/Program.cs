using System.Text.Json;
using TwistedFizzBuzz;

var res = TwistedFizzBuzzHelper.FromRange(
    -20,
    127,
    new()
    {
        { 5, "Fizz" },
        { 9, "Buzz" },
        { 27, "Bar" },
    },
    true
);

// Output numbers from -20 to 127 following the rules
Console.WriteLine(JsonSerializer.Serialize(res));
