namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _service;

    public StringCalculator(ILogger logger, IWebService service)
    {
        _logger = logger;
        _service = service;
    }


    public int Add(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }

        // select - map
        var result = numbers.Split(',', '\n') // => ["1", "2", "3"...]
            .Select(int.Parse) // => [1,2,3,4,6]
            .Sum(); // Language Integrated Query

        try
        {
            _logger.Write(result.ToString());
        }
        catch (Exception)
        {

            _service.NotifyOfLoggingFailure();
        }
        return result;

    }

    public int Add(string numbers, int startingAt)
    {
        return Add(startingAt.ToString() + ", " + numbers);
    }

    public int Add(string numbers, bool singleDigitOnly)
    {
        return -42;
    }

}

public interface IWebService
{

    void NotifyOfLoggingFailure();
}

public interface ILogger
{
    void Write(string message);
}

public class LoggingException : ApplicationException { };