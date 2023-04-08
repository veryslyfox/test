static class TextAnalysis
{
    static double[,] MarkovChain = new double[33, 33];
    static double[,] MarkovChainNext = new double[33, 33];
    static Random _rng = new Random();
    public static char Next(char a)
    {
        var prob = new double[33];
        for (int i = 0; i < 33; i++)
        {
            prob[i] = MarkovChain[a, i];
        }
        return (char)Random(prob);
    }
    public static char NextToken(char a)
    {
        var prob = new double[33];
        for (int i = 0; i < 33; i++)
        {
            prob[i] = MarkovChainNext[a, i];
        }
        return (char)Random(prob);
    }
    public static void NewText(string file)
    {
        var stream = File.OpenText(file);
        while (true)
        {
            var result = stream.ReadLine();
            if (result == null)
            {
                return;
            }
            result.Split(' ');
        }
    }
    public static void NewText(string[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < s[i].Length - 1; j++)
            {
                MarkovChain[s[i][j], s[i][j + 1]]++;
            }
            if (i != s.Length - 1)
            {
                MarkovChainNext[s[i][s[i].Length - 1], s[i + 1][0]]++;
            }
        }
    }
    static int Random(double[] prob)//?
    {
        var next = _rng.Next();
        var sum = prob.Aggregate((double a, double b) => a + b);
        var probs = prob.Select((double a) => a / sum).ToArray();
        probs.Select((double d, int i) => { if (next < probs[1..i].Sum()) { return i; } return 0; });
        return 0;
    }
}