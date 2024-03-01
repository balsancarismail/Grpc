// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcMessageClient;

var chanel = GrpcChannel.ForAddress("http://localhost:5028");
var client = new Message.MessageClient(chanel);

var request = client.GetMessage();

int i = 0;
while (i++ < 10)
{
    await request.RequestStream.WriteAsync(new MessageRequest { Name = "John", Message = "Hello" });
    await Task.Delay(1000);
}
await request.RequestStream.CompleteAsync();
var resp = request.ResponseAsync.Result;

Console.WriteLine(resp.Message);