// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcMessageClient;

var chanel = GrpcChannel.ForAddress("http://localhost:5028");
var client = new Message.MessageClient(chanel);

var response = client.GetMessage(new MessageRequest { Message = "Sanchez" });

while (await response.ResponseStream.MoveNext(CancellationToken.None))
    Console.WriteLine($"Received: {response.ResponseStream.Current.Message}");