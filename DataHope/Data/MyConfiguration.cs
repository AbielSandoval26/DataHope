namespace DataHope.Data
{
    public class MyConfiguration
    {
        public string CosmosDatabaseName { get; set; }
        public string CosmosEndpointURL { get; set; }
        public string CosmosAPIKey { get; set; }
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string MailUsername { get; set; }
        public string MailPassword { get; set; }
        public string NotificationSender { get; set; }
        public string NotificationRecipient { get; set; }
    }
}
