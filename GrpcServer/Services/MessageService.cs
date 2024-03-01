using Grpc.Core;

namespace GrpcMessageServer.Services;

public class MessageService(ILogger<MessageService> logger) : Message.MessageBase
{
    public override async Task<MessageResponse> GetMessage(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
    {

        while (await requestStream.MoveNext(context.CancellationToken))
        {
            logger.LogInformation("Received: " + requestStream.Current.Name + " | Message: " + requestStream.Current.Message);
        }

        return new MessageResponse
        {
            Message = "Hello " + requestStream.Current.Name
        };
    }
}