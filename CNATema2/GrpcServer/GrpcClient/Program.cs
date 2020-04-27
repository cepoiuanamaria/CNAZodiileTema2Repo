using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ZodiacService.ZodiacServiceClient(channel);

            Console.WriteLine("Date of birth: ");
            var dobInput = Console.ReadLine();
            DateTime date;
            try
            {
                string dateFormat = "MM/dd/yyyy";
                date = DateTime.ParseExact(dobInput, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);

                var response = client.ZodiacSignInfo(new DOBRequest
                {
                    Data = dobInput
                });
                Console.WriteLine(response.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("The date introduced is invalid!");
            }
            //Console.ReadLine();
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
