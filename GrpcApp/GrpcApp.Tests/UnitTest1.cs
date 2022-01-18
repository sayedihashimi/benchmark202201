using Grpc.Net.Client;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace GrpcApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

[Test]
public async Task Test1()
{
    var channel = GrpcChannel.ForAddress("https://localhost:7283");
            
    var client = new Greeter.GreeterClient(channel);
    var response = await client.SayHelloAsync(
        new HelloRequest
        {
            Name = "benchmark"
        });

    Console.WriteLine(response);
    Assert.IsNotNull(response.Message);
    Assert.True(string.Equals("Hello benchmark",response.Message));
    //var response = await client.SayHelloAsync(
    //    new HelloRequest { Name = "World" });

    //Console.WriteLine(response.Message);
}
    }
}