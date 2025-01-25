namespace TwistedFizzBuzz;

public class TwistedFizzBuzzHelper
{
    private static readonly Dictionary<int, string> defaultNumberPerToken = new()
    {
        { 3, "Fizz" },
        { 5, "Buzz" },
    };

    public static string[] FromRange(
        int start,
        int end,
        Dictionary<int, string>? numberPerToken = null,
        bool shouldCombinateRules = false
    )
    {
        if (end < start)
        {
            throw new Exception("The end parameter should be higher than the start");
        }

        int[] rangeArray = [.. Enumerable.Range(start, end - start + 1)];

        return GetFizzBuzz(rangeArray, numberPerToken, shouldCombinateRules);
    }

    private static string[] GetFizzBuzz(
        int[] numbers,
        Dictionary<int, string>? numberPerToken = null,
        bool shouldCombinateRules = false
    )
    {
        numberPerToken ??= defaultNumberPerToken;
        int length = numbers.Length;
        string[] result = new string[length];

        for (int i = 0; i < length; i++)
        {
            int num = numbers[i];
            string curToken = "";

            foreach (var (ruleNum, token) in numberPerToken)
            {
                if (num % ruleNum == 0)
                {
                    curToken += string.IsNullOrEmpty(curToken) ? token : $"-{token}";

                    if (!shouldCombinateRules)
                    {
                        break;
                    }
                }
            }

            result[i] = string.IsNullOrEmpty(curToken) ? num.ToString() : curToken;
        }

        return result;
    }
}
