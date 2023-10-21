namespace pokedexData.Contexts
{
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    public class MongoDbContext 
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            try {
                MongoClient client = new MongoClient(connectionString);
                _database = client.GetDatabase(databaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to MongoDB: " + ex.Message, ex);
            }
        }
    }
}