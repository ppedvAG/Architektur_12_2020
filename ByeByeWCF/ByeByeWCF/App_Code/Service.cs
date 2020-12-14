public class Service : IService
{
    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    public string SagHallo(string name)
    {
        return "Hallo " + name;
    }

    public int Verdoppeln(int zahl)
    {
        return zahl * 2;
    }
}
