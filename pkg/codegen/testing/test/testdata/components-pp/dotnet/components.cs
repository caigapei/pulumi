using System.Collections.Generic;
using System.Linq;
using Pulumi;

return await Deployment.RunAsync(() => 
{
    var simpleComponent = new Components.SimpleComponent("simpleComponent");

    var exampleComponent = new Components.ExampleComponent("exampleComponent", new()
    {
        Input = "doggo",
        IpAddress = new[]
        {
            127,
            0,
            0,
            1,
        },
        CidrBlocks = 
        {
            { "one", "uno" },
            { "two", "dos" },
        },
        GithubApp = new Components.ExampleComponentArgs.GithubAppArgs
        {
            Id = "example id",
            KeyBase64 = "base64 encoded key",
            WebhookSecret = "very important secret",
        },
        Servers = new[]
        {
            new Components.ExampleComponentArgs.ServersArgs
            {
                Name = "First",
            },
            new Components.ExampleComponentArgs.ServersArgs
            {
                Name = "Second",
            },
        },
        DeploymentZones = 
        {
            { "first", new Components.ExampleComponentArgs.DeploymentZonesArgs
            {
                Zone = "First zone",
            } },
            { "second", new Components.ExampleComponentArgs.DeploymentZonesArgs
            {
                Zone = "Second zone",
            } },
        },
    });

    return new Dictionary<string, object?>
    {
        ["result"] = exampleComponent.Result,
    };
});

