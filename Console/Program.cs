// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

Console.WriteLine("Hello, World!");

var chanel = GrpcChannel.ForAddress("http://localhost:5028");
var client = new Greeter.GreeterClient(chanel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
