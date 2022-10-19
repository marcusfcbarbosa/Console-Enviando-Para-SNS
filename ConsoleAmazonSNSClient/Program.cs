using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using ConsoleAmazonSNSClient.Extensions;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleAmazonSNSClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.SAEast1);
            SendMessage(client).Wait();
        }
        static async Task SendMessage(IAmazonSimpleNotificationService snsClient)
        {
            try
            {
                int count = 50;
                do
                {
                    var request = new PublishRequest
                    {

                        TopicArn = Acceess.GetTopiARN(),
                        Message = JsonSerializer.Serialize(new EnvioTitulo
                        {

                            idLinha = Guid.NewGuid().ToString(),
                            codEspecieDoc = "22222222",
                            seuNumero = "33333333",
                            dataVencimento = DateTime.Now
                        }),Subject= $"ENVIO TITUTLOS MARCUS {DateTime.Now.ToString()}"
                    };
                    await snsClient.PublishAsync(request);
                    count--;
                } while (count > 0);
            }
            catch(Exception ex)
            {
                string erro = ex.Message;
            }
           
        }
        public class EnvioTitulo
        {
            public string idLinha { get; set; }
            public string codEspecieDoc { get; set; }
            public string seuNumero { get; set; }
            public DateTime dataVencimento { get; set; }

        }
        
    }
}

