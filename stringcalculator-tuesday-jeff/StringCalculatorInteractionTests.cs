namespace StringCalculator;
public class StringCalculatorInterationTests
{
    private readonly StringCalculator _calculator;
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculatorInterationTests()
    {
        _logger = Substitute.For<ILogger>();
        _webService = Substitute.For<IWebService>();
        _calculator = new StringCalculator(_logger, _webService);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("1,2")]
    public void WritesToLogger(string numbers)
    {
        _calculator.Add(numbers);

        // Assert???
        _logger.Received().Write(numbers);
        _webService.DidNotReceive().NotifyOfLoggingFailure();
    }

    [Fact]
    public void SendsMessageToApiIfLoggerFails()
    {
        _logger.When(m => m.Write("999")).Do(x => throw new LoggingException());
        //Stub - just provides canned answers.
        //_logger.When(b => b.Write("999")).Throws<LoggingException>();
        _calculator.Add("999");

        _webService.Received(1).NotifyOfLoggingFailure();

    }
}
