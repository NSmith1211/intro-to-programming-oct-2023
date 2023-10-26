using Alba;

namespace DemoApi.ContractTests.Todos;
public class GettingTodos
{

    [Fact]
    public async Task CanGetATodo()
    {
        var host = await AlbaHost.For<Program>();

        await host.Scenario(api =>
        {
            api.Get.Url("/todo-list/5481ece9-3363-472d-9b44-8a850ee2f24d");
            api.StatusCodeShouldBeOk();
        });

        await host.Scenario(api =>
        {
            api.Get.Url("/todo-list/" + Guid.NewGuid().ToString());
            api.StatusCodeShouldBe(404);

        });
    }
}