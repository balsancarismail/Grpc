// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcMessageClient;
using GrpcServer;


var chanel = GrpcChannel.ForAddress("http://localhost:5028");
var client = new Message.MessageClient(chanel);

var response = await client.GetMessageAsync(new MessageRequest { Message = "Sanchez" });

Console.WriteLine(response.Message); 
