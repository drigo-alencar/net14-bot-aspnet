namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Username { get; internal set; }
        public string Id { get; internal set; }
        public string Count { get; internal set; }

        public string Reply(SimpleMessage message)
        {
            return $"{message.User} disse '{message.Text}";
        }

        //rodrigo 332098
    }
}