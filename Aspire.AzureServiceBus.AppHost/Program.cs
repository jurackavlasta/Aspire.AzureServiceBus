var builder = DistributedApplication.CreateBuilder(args);

// Create emulator service bus
var serviceBus = builder.AddAzureServiceBus("messaging")
                        .RunAsEmulator();

serviceBus.AddServiceBusTopic("Test", "aspire.azureservicebus.messages/testmessage");

// Create api service
var apiService = builder.AddProject<Projects.Aspire_AzureServiceBus_ApiService>("apiservice")
                        .WaitFor(serviceBus)
                        .WithReference(serviceBus);

// Create another api service
var anotherApiService = builder.AddProject<Projects.Aspire_AzureServiceBus_AnotherApiService>("anotherapiservice")
                               .WaitFor(serviceBus)
                               .WithReference(serviceBus);

builder.Build().Run();
