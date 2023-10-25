
using DemoApi.Services;

namespace DemoApi.UnitTests;
public class TemperatureConverterServiceTests
{

    [Fact]
    public void UsesTheFeeCalculator()
    {
        //Given

        var fakeFeeCalculator = Substitute.For<ICalculateFees>();
        fakeFeeCalculator.GetCurrentFee().Returns(42.23M);
        var service = new TemperatureConverterService(fakeFeeCalculator);
        //When
        ConversionWithFeeResponse response = service.ConvertFtoC(100F);
        //Then
        Assert.Equal(42.23M, response.Fee);
    }
}
//Test Double
public class StubbedFeeThing : ICalculateFees
{
    public decimal GetCurrentFee()
    {
        return 5;
    }
}


/* {
	"f":100,
	"c":37.77778,
	"fee": 0	
}
 
 
{
	"f":100,
	"c":37.77778
	"fee": 0.03	
} */