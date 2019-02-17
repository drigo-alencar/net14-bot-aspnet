using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
		
		public string Username { get; internal set; }
		public string Id { get; internal set; }

		public string Reply(SimpleMessage message)
        {
            return $"{message.User} disse '{message.Text}";
        }

		
	}
}