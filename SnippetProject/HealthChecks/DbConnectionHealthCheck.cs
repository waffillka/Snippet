using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace SnippetProject.HealthChecks
{
    public class DbConnectionHealthCheck : IHealthCheck
    {
        public string TestQuery { get; }
        public string ConnectionString { get; }

        public DbConnectionHealthCheck(string connectionString, string testQuery = "Select 1;")
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException("Connection string is null");
            TestQuery = testQuery;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken ct = default)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync(ct).ConfigureAwait(false);

                    var command = connection.CreateCommand();
                    command.CommandText = TestQuery;
                    await command.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                }
                catch (DbException ex)
                {
                    return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
                }
            }

            return HealthCheckResult.Healthy();
        }
    }
}
