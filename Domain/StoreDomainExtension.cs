using System;
using Domain.Aggregates;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB;
using RabbitMQ.Client;

namespace Domain
{
    public static class StoreDomainExtension
    {
        public static IServiceCollection AddStoreDomain(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoConnection>(opts =>
            {
                opts.ConnectionString = config.GetSection("MongoConnection:ConnectionString").Value;
                opts.Database = config.GetSection("MongoConnection:Database").Value;
            });

            services.AddSingleton<IModel>(opts =>
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "retailer",
                                                        durable: false,
                                                        exclusive: false,
                                                        autoDelete: false,
                                                        arguments: null);

                return channel;
            });

            services.AddTransient<IRetailerRepository, RetailerRepository>();
            services.AddTransient<StoreDomain>();
            services.AddTransient<StoreAggregate>();

            services.AddTransient<MongoContext>();

            return services;
        }
    }
}
