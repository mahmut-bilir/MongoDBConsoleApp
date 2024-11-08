using MongoDB.Bson;
using MongoDB.Driver;

var client = new MongoClient("mongodb://localhost:27017");

var database = client.GetDatabase("testdb");

var collection = database.GetCollection<BsonDocument>("persons");

var person = new BsonDocument
{
    { "name", "Mahmut" },
    { "age", 30 },
    { "profession", "Software Developer" }
};

await collection.InsertOneAsync(person);
Console.WriteLine("Data Inserted!");

var filter = Builders<BsonDocument>.Filter.Eq("name", "Mahmut");
var result = await collection.Find(filter).ToListAsync();

foreach (var doc in result)
{
    Console.WriteLine(doc);
}
