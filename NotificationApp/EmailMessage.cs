namespace NotificationApp.Test
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string ToAddress { get;  set; }
        public string ToName { get;  set; }
     
        public bool IsHtml { get; set; }
        public string Bcc { get;  set; }
        public string Cc { get; set; }
    }
}