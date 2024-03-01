// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcMessageClient;

var chanel = GrpcChannel.ForAddress("http://localhost:5028");
var client = new Message.MessageClient(chanel);

var request = client.GetMessage();

var task = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        await request.RequestStream.WriteAsync(new MessageRequest { Name = "John", Message = $"Message {i}" });
    }
    
});

while (await request.ResponseStream.MoveNext(CancellationToken.None))
{
    var resp = request.ResponseStream.Current;
    Console.WriteLine(resp.Message);
}

await task;
await request.RequestStream.CompleteAsync();
