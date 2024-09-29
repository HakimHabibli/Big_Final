using Loging.Api.Models;
using MongoDB.Driver;
public class MongoLogService : ILogService
{
    private readonly IMongoCollection<LogEntry> _logCollection;

    public MongoLogService()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("LogingDb_EHospital");
        _logCollection = database.GetCollection<LogEntry>("Log");
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