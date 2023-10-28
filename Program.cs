using System;
using StackExchange.Redis;

namespace AzureRedisConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //check if connection string is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a redis connection string");
                return;
            }

            //get connection string from command line argument
            string redisConnectionString = args[0];
            Console.WriteLine("Connection string from cmd line = " + redisConnectionString);

            Console.WriteLine("Retrieving Redis connection");
            // Connect to the Azure Redis Cache instance.
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);

            Console.WriteLine("Getting Redis DB");
            // Perform cache operations using the cache object...
            //store session id in cache
            IDatabase cache = redisConnection.GetDatabase();

            Console.WriteLine("Setting value in Redis");

            cache.StringSet("key1", "Hello");
            //retrieve session id from cache
            Console.WriteLine("Getting value from Redis");
            string value = cache.StringGet("key1");
            Console.WriteLine(value);

            //write to cache
            cache.StringSet("message", "Connection to Redis was successful");
            //read hello ameer from cache
            string msg = cache.StringGet("message");
            Console.WriteLine(msg);

              
        }
    }
}

