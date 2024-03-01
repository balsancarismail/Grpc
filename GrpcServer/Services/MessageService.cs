using Grpc.Core;

namespace GrpcMessageServer.Services
{
    public class MessageService(ILogger<MessageService> logger) : Message.MessageBase
    {
        public override Task<MessageResponse> GetMessage(MessageRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Message: {request.Message} | Name: {request.Name}");
            return Task.FromResult(new MessageResponse()
            {
                Message = "Message received successfully!"
            });
        }
    }
}