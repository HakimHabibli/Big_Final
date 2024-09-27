using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Loging.Api.Models;

public class LogEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Message { get; set; }
    [BsonRepresentation(BsonType.String)]
    public LogLevel LogLevel { get; set; }
    public DateTime Timestamp { get; set; }

}
public enum LogLevel
{
    Trace,
    Debug,
    Information,
    Warning,
    Error,
    Critical
}
