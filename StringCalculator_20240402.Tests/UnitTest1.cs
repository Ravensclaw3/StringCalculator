namespace StringCalculator_20240402.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("",0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("1\n2,3", 6)]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//#\n1#2", 3)]
    [InlineData("//K\n1K2", 3)]
    [InlineData("1001,2", 2)]
    [InlineData("//[##]\n1##2", 3)]
    [InlineData("//[***]\n1***2***3", 6)]
    [InlineData("//[*][%]\n1*2%3", 6)]
    [InlineData("//[@][#]\n1@2#3@4", 10)]
    [InlineData("//[***][%%%]\n1***2%%%3", 6)]
    [InlineData("//[##][WW]\n1##2WW3##4", 10)]
    public void TestArguments(string input, int expectation)
    {
        var calc = new Calculator();
        var result = calc.Add(input);

        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("1,2,-3,4", "negatives not allowed -3")]
    [InlineData("1,-8,-2,5", "negatives not allowed -8 -2")]

    public void TestExceptions(string input, string expectation)
    {
        var calc = new Calculator();
        var ExceptionMessage = Assert.Throws<ArgumentException>(() => calc.Add(input));

        Assert.Equal(expectation, ExceptionMessage.Message);
    }
}