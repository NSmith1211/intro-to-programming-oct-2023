using Alba;

namespace DemoApi.ContractTests.Temperatures;
public class ConversionTests
{
    [Fact]
    public async Task CanCovertFromFToC()
    {
        var expectedResponse = new ConversionResponse(212, 100);

        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/temperatures/farenheit/212/celcius");
            api.StatusCodeShouldBeOk();
        });

        var message = response.ReadAsJson<ConversionResponse>();

        Assert.NotNull(message);
        Assert.Equal(expectedResponse, message);
    }

    [Fact]
    public async Task CanCovertFromCToF()
    {
        var expectedResponse = new ConversionResponse(212, 100);

        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/temperatures/celcius/100/farenheit");
            api.StatusCodeShouldBeOk();
        });

        var message = response.ReadAsJson<ConversionResponse>();

        Assert.NotNull(message);
        Assert.Equal(expectedResponse, message);
    }
}
