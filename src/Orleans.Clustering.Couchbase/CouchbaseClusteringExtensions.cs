using Microsoft.Extensions.DependencyInjection;
using Orleans.Configuration;
using Orleans.Hosting;
using System;

namespace Orleans.Clustering.Couchbase
{
    public static class CouchbaseClusteringExtensions
    {
        public static ISiloHostBuilder UseCouchbaseClustering(this ISiloHostBuilder builder,
            Action<CouchbaseClusteringOptions> configureOptions)
        {
            return builder.ConfigureServices(
                services =>
                {
                    if (configureOptions != null)
                    {
                        services.Configure(configureOptions);
                    }

                    services.AddSingleton<IMembershipTable, CouchbaseMembershipTable>()
                        .ConfigureFormatter<CouchbaseClusteringOptions>();
                });
        }

    }
}
