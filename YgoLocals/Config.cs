namespace YgoLocals
{
    public class Config
    {
        public EmailSettings EmailSettings { get; set; }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string Mail { get; set; }

        public string Pass { get; set; }
    }
}
