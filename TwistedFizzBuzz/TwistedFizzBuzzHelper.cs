namespace TwistedFizzBuzz;

public class TwistedFizzBuzzHelper
{
    private static string[] GetFizzBuzz(
        int[] numbers,
        Dictionary<int, string> numberPerToken,
        bool shouldCombinateRules = false
    )
    {
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
