namespace TwistedFizzBuzz;

public class TwistedFizzBuzzHelper
{
    private static readonly Dictionary<int, string> defaultNumberPerToken = new()
    {
        { 3, "Fizz" },
        { 5, "Buzz" },
    };

    private static int[] GetArrayFromRange(int start, int end)
    {
        bool isAscending = start < end;
        int arrayLength = Math.Abs(end - start) + 1;
        int[] rangeArray = new int[arrayLength];

        for (int i = 0; i < arrayLength; i++)
        {
            rangeArray[i] = isAscending ? start + i : start - i;
        }

        return rangeArray;
    }

    public static string[] FromRange(
        int start,
        int end,
        Dictionary<int, string>? numberPerToken = null,
        bool shouldCombinateRules = false
    )
    {
        return GetFizzBuzz(GetArrayFromRange(start, end), numberPerToken, shouldCombinateRules);
    }

    public static string[] GetFizzBuzz(
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
