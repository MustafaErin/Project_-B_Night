﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project__B_Night.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool İsRead { get; set; }
        public string Image { get; set; }


    }
}