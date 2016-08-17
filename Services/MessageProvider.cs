namespace NancyExample.Services
{
    public class MessageProvider: IMessageProvider
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}