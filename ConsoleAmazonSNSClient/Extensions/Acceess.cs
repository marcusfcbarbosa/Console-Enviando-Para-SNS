using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAmazonSNSClient.Extensions
{
    public static class Acceess
    {
        public static string GetRoute()
        {
            return GetSeetings().GetValue<string>("Queue");
        }
        public static string GetTopiARN()
        {
            return GetSeetings().GetValue<string>("SNS_ARN");
        }
        public static IConfigurationRoot GetSeetings()
        {
            return new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsetttings.json")
               .AddEnvironmentVariables() 
               .Build();
        }
        public static AmazonSQSClient GetCredentials()
        {
            var accessKey = GetSeetings().GetValue<string>("AccessKey");
            var secret = GetSeetings().GetValue<string>("Secret");
            var credential = new BasicAWSCredentials(accessKey, secret);
            return new AmazonSQSClient(credentials: credential, region: Amazon.RegionEndpoint.SAEast1);
        }
    }
}
