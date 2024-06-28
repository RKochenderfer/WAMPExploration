using WampSharp.V2.Rpc;

namespace WampExploration;

public interface IArgumentsService
{
    [WampProcedure("com.arguments.ping")]
    string Ping();

    [WampProcedure("com.arguments.add2")]
    int Add2(int a, int b);
}
