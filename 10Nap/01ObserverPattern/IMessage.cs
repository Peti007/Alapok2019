namespace _01ObserverPattern
{
    public interface IMessage
    {
        int Data { get; set; }
        string Text { get; set; }
    }
}