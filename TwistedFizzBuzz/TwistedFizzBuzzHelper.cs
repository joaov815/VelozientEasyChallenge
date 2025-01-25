namespace TwistedFizzBuzz;

public class TwistedFizzBuzzHelper
{
    private static readonly Dictionary<int, string> defaultDivisorPerToken = new()
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
        Dictionary<int, string>? divisorPerToken = null,
        bool shouldCombinateRules = false
    )
    {
        return GetFizzBuzz(GetArrayFromRange(start, end), divisorPerToken, shouldCombinateRules);
    }

    public static string[] GetFizzBuzz(
        int[] numbers,
        Dictionary<int, string>? divisorPerToken = null,
        bool shouldCombinateRules = false
    )
    {
        divisorPerToken ??= defaultDivisorPerToken;
        int length = numbers.Length;
        string[] result = new string[length];

        for (int i = 0; i < length; i++)
        {
            int num = numbers[i];
            string curToken = "";

            foreach (var (ruleNum, token) in divisorPerToken)
            {
                if (num % ruleNum == 0)
                {
                    curToken += token;

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
