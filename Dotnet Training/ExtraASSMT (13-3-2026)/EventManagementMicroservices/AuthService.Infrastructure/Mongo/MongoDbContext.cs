using AuthService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Mongo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase database;

        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDb:ConnectionString"]);
            database = client.GetDatabase(config["MongoDb:Database"]);
        }

        public IMongoCollection<User> Users =>
            database.GetCollection<User>("Users");
    }
}
