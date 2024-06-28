namespace WampExploration;

public class ArgumentsService : IArgumentsService
{
    public string Ping()
    {
        return "Pong";
    }

    public int Add2(int a , int b)
    {
        return a + b;
    }
}
