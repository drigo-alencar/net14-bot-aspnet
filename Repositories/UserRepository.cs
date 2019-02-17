using MongoDB.Driver;
using SimpleBot.Logic;
using System;
using System.Configuration;

namespace SimpleBot.Repositories
{
	public class UserRepository
	{
		private IMongoCollection<SimpleBotUser> collection;

		public UserRepository(IMongoDatabase db)
		{
			this.collection = db.GetCollection<SimpleBotUser>("users");
		}

		internal SimpleBotUser GetProfile(SimpleBotUser user)
		{
			return null;
		}

		internal void SetProfile(SimpleBotUser user)
		{
			
		}
	}
}