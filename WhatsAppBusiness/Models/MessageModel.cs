﻿namespace WhatsAppBusiness.Models
{
    public class MessageModel
    {
        public string? PhoneId { get; set; }
        public string? messaging_product { get; set; }
        public string? to { get; set; }
        public string? type { get; set; }
        public Template? template { get; set; }
    }
    public class Template
    {
        public string? name { get; set; }
        public Language? language { get; set; }
    }
    public class Language
    {
        public string? code { get; set; }
    }
}
