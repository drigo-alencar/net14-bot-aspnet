using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot.Repositories
{
	public class UnitOfWork
	{
		private const string MONGO_CONNECTION_STRING_NAME = "Mongo";
		private const string MONGO_DATABASE = "BotBase";

		private IMongoDatabase db;
		private MessageRepository messageRepository;

		public UnitOfWork()
		{
			db = new MongoClient(GetConnectionString()).GetDatabase(MONGO_DATABASE);
		}

		private static string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings[MONGO_CONNECTION_STRING_NAME].ConnectionString;
		}

		public MessageRepository MessageRepository
		{
			get
			{
				if (this.messageRepository == null) { this.messageRepository = new MessageRepository(db); }
				return this.messageRepository;
			}
		}
	}
}