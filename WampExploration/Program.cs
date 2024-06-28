using System.Reactive.Linq;
using WampExploration;
using WampSharp.V2;

const string location = "ws://127.0.0.1:8080/ws";

using var host = new DefaultWampHost(location);

var argumentsService = new ArgumentsService();
var realm = host.RealmContainer.GetRealmByName("realm1");
await realm.Services.RegisterCallee(argumentsService);

host.Open();

Console.WriteLine($"Server is running on {location}");

var subject = realm.Services.GetSubject<int>("com.pubsub.topic1");
var counter = 0;
var timer = Observable.Timer(TimeSpan.FromMicroseconds(0), TimeSpan.FromMilliseconds(1000));

IDisposable disposable = timer.Subscribe(x => 
{
    counter++;
    Console.WriteLine("Publishing to topic 'com.myapp.topic1': " + counter);
    try 
    {
        subject.OnNext(counter);
    } catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
});

Console.ReadLine();
