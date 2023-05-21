using System.Text;

var denominations = new[] { 10, 50, 100 };
var payouts = new[] { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

// Loop through all payouts and compute the combinations for each payout
foreach (var payout in payouts)
{
    Console.WriteLine($"Payout: {payout} EUR");

    var combinations = GetCombinations(payout, denominations, 0, new Dictionary<string, List<int>>());
    foreach (var combination in combinations.Values)
    {
        PrintCombination(combination);
    }
    Console.WriteLine();
}

static void PrintCombination(List<int> combination)
{
    var counts = new Dictionary<int, int>();
    foreach (var denomination in combination)
    {
        if (counts.ContainsKey(denomination))
        {
            counts[denomination]++;
        }
        else
        {
            counts[denomination] = 1;
        }
    }

    var result = new StringBuilder();
    foreach (var pair in counts)
    {
        result.Append($"{pair.Value} x {pair.Key} EUR, ");
    }

    Console.WriteLine(result.ToString().TrimEnd(',', ' '));
}

static Dictionary<string, List<int>> GetCombinations(int remaining, int[] denominations, int currentDenomination, Dictionary<string, List<int>> combinations)
{
    if (remaining == 0 || currentDenomination >= denominations.Length)
    {
        return combinations;
    }

    // Calculate how many times the current denomination can be used
    var denominationCount = remaining / denominations[currentDenomination];

    for (var i = denominationCount; i >= 0; i--)
    {
        var newRemaining = remaining - denominations[currentDenomination] * i;
        var combination = new List<int>();

        for (var j = 0; j < i; j++)
        {
            combination.Add(denominations[currentDenomination]);
        }

        if (newRemaining > 0)
        {
            // Call recursively with the new remaining amount and the next denomination
            var newCombinations = GetCombinations(newRemaining, denominations, currentDenomination + 1, new Dictionary<string, List<int>>());
            foreach (var newCombination in newCombinations.Values)
            {
                var totalCombination = new List<int>(combination);
                totalCombination.AddRange(newCombination);
                combinations[string.Join(',', totalCombination)] = totalCombination;
            }
        }
        else
        {
            combinations[string.Join(',', combination)] = combination;
        }
    }

    return combinations;
}