
namespace StringCalculator_20240402;

public class Calculator
{
    public int Add(string input)
    {
        var result = 0;
        char[] delim = Delimeter(input);

        if (String.IsNullOrEmpty(input)) return result;

        result = CalcValue(input, delim);

        return result;
    }

    private static int CalcValue(string input, char[] delim)
    {
        int result;
        int[] val = input.Split(delim).Select((s, i) => int.TryParse(s, out i) ? i : 0).ToArray();

        if (val.Min() < 0)
        {
            throw new ArgumentException("negatives not allowed " + String.Join(" ", val.Where(s => s < 0)));
        }

        result = val.Where(s => s < 1001).Sum();
        return result;
    }

    private static char[] Delimeter(string input)
    {
        char[] delim;
        if (input.StartsWith("//"))
        {
            delim = input.Substring(input.IndexOf("//") + 2, input.IndexOf("\n") - 2).ToCharArray();
        }
        else { delim = [',', '\n']; }

        return delim;
    }
}
