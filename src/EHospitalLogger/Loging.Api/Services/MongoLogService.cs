using Loging.Api.Models;
using MongoDB.Driver;
public class MongoLogService : ILogService
{
    private readonly IMongoCollection<LogEntry> _logCollection;

    public MongoLogService(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _logCollection = database.GetCollection<LogEntry>(collectionName);
    }

    public async Task LogAsync(LogEntry logEntry)
    {
        if (logEntry != null)
        {
            await _logCollection.InsertOneAsync(logEntry);
        }
    }
}

public interface ILogService
{
    Task LogAsync(LogEntry logEntry);
}