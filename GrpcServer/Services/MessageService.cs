using Grpc.Core;

namespace GrpcMessageServer.Services;

public class MessageService(ILogger<MessageService> logger) : Message.MessageBase
{
    public override async Task GetMessage(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {

        var respTask = Task.Run(async () =>
        {
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                var request = requestStream.Current;
                Console.WriteLine($"Hello from Server {request.Name}, you said: {request.Message}");
            }
        });

        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            await responseStream.WriteAsync(new MessageResponse { Message = $"Message {i}" });
        }

        await respTask;
    }
}