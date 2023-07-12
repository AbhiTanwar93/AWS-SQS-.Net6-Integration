using Amazon.SQS;
using SQS_Service_Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<OrderCreatedEventConsumer>();
        services.AddSingleton<IAmazonSQS>(sp =>
        {
            var clientConfig = new AmazonSQSConfig
            {
                ServiceURL = "http://localhost:4566/"
            };
            return new AmazonSQSClient("accessKey", "secretKey", clientConfig);
        });
    })
    .Build();

await host.RunAsync();
