using TwistedFizzBuzz;

namespace TwistedFizzBuzzTests;

public class TwistedFizzBuzzHelperTests
{
    public static IEnumerable<object[]> DataForCustomRuleTest =>
        [
            [
                1,
                357,
                new Dictionary<int, string>
                {
                    { 7, "Poem" },
                    { 17, "Writer" },
                    { 3, "College" },
                },
                true,
            ],
        ];

    [Theory]
    [InlineData(1, 50)]
    [InlineData(1, 2_000_000_000)]
    [InlineData(-2, -37)]
    public async Task TestRangesForTheDefaultProblem(int start, int end)
    {
        const int chunkSize = 10_000_000;
        int currentStart = start;

        while (currentStart < end)
        {
            int currentEnd = Math.Min(currentStart + chunkSize, end);

            await Task.Run(() =>
            {
                string[] tokens = TwistedFizzBuzzHelper.FromRange(currentStart, currentEnd);
                for (int i = 0; i < tokens.Length; i++)
                {
                    string tokenOrNumber = tokens[i];
                    int number = currentStart + i;

                    if (number % 3 == 0)
                    {
                        Assert.Equal("Fizz", tokenOrNumber);
                    }
                    else if (number % 5 == 0)
                    {
                        Assert.Equal("Buzz", tokenOrNumber);
                    }
                    else
                    {
                        Assert.Equal(int.Parse(tokenOrNumber), number);
                    }
                }
            });

            currentStart = currentEnd + 1;
        }
    }

    [Theory]
    [InlineData(new int[] { -5, 6, 300, 12, 15 })]
    public void TestNonSequencial(int[] nonSequencial)
    {
        string[] tokens = TwistedFizzBuzzHelper.GetFizzBuzz(nonSequencial);

        for (int i = 0; i < tokens.Length; i++)
        {
            string tokenOrNumber = tokens[i];
            int number = nonSequencial[i];

            if (number % 3 == 0)
            {
                Assert.Equal("Fizz", tokenOrNumber);
            }
            else if (number % 5 == 0)
            {
                Assert.Equal("Buzz", tokenOrNumber);
            }
            else
            {
                Assert.Equal(int.Parse(tokenOrNumber), number);
            }
        }
    }

    [Theory]
    [MemberData(nameof(DataForCustomRuleTest))]
    public void CustomRule(
        int start,
        int end,
        Dictionary<int, string> divisorPerToken,
        bool shouldCombinateRules
    )
    {
        string[] tokens = TwistedFizzBuzzHelper.FromRange(
            start,
            end,
            divisorPerToken,
            shouldCombinateRules
        );

        for (int i = 0; i < tokens.Length; i++)
        {
            int number = start < end ? (start + i) : (start - i);
            string expected = "";

            foreach (var (divisor, token) in divisorPerToken)
            {
                if (number % divisor == 0)
                {
                    expected += token;

                    if (!shouldCombinateRules)
                    {
                        break;
                    }
                }
            }

            if (expected == "")
            {
                expected = number.ToString();
            }

            Assert.Equal(expected, tokens[i]);
        }
    }
}
