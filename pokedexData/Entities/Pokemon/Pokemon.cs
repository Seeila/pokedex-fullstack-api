namespace pokedexData.Entities.Pokemon
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Transactions;

    [BsonDiscriminator("pokemon")]
    public class Pokemon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
