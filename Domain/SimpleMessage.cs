using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Logic
{
    public class SimpleMessage
    {
		[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
		public string Id { get; set; }

		public string UserId { get; set; }

		public string User { get; set; }

		public string Text { get; set; }

        public SimpleMessage(string userId, string username, string text)
        {
            this.UserId = userId;
            this.User = username;
            this.Text = text;
        }
    }
}