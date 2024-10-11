using Loging.Api.Models;
using MongoDB.Driver;
public class MongoLogService : ILogService
{
    private readonly IMongoCollection<LogEntry> _logCollection;


    public MongoLogService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("LogingDb_EHospital");
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