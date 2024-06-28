using WampExploration;
using WampSharp.V2;

const string location = "ws://127.0.0.1:8080/ws";

using var host = new DefaultWampHost(location);

var argumentsService = new ArgumentsService();
var realm = host.RealmContainer.GetRealmByName("realm1");
await realm.Services.RegisterCallee(argumentsService);

host.Open();

Console.WriteLine($"Server is running on {location}");
Console.ReadLine();
