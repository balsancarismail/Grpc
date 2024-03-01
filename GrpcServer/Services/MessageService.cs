using Grpc.Core;

namespace GrpcMessageServer.Services;

public class MessageService(ILogger<MessageService> logger) : Message.MessageBase
{
    public override async Task GetMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream,
        ServerCallContext context)
    {
        Console.WriteLine($"Received request for {request.Name}");
        for (var i = 0; i < 10; i++)
        {
            await responseStream.WriteAsync(new MessageResponse { Message = $"Hello {request.Name} {i}" });
            await Task.Delay(1000);
        }
    }
}