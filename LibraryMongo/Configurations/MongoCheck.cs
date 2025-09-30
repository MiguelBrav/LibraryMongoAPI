using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace LibraryMongo.Configurations;

public class MongoCheck : IHealthCheck
{
    private readonly IMongoClient _client;
    private readonly string _databaseName;

    public MongoCheck(IMongoClient client, IConfiguration config)
    {
        _client = client;
        _databaseName = config["MongoDb:DatabaseName"] ?? string.Empty;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var db = _client.GetDatabase(_databaseName);

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(TimeSpan.FromSeconds(15));

            await db.RunCommandAsync((Command<MongoDB.Bson.BsonDocument>)"{ping:1}", cancellationToken: cts.Token);

            return HealthCheckResult.Healthy("MongoDB is reachable.");
        }
        catch (OperationCanceledException)
        {
            return HealthCheckResult.Unhealthy("MongoDB ping timed out.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("MongoDB is not reachable.", ex);
        }
    }
}
