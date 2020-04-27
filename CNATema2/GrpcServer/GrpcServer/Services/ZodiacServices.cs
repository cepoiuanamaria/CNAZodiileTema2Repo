using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class ZodiacServices:ZodiacService.ZodiacServiceBase
    {
        public List<ZodiacSigns> listZodiacSigns = new List<ZodiacSigns>();
        private string verifyTest(string dateTested)
        {
            string dateFormat = "MM/dd/yyyy";
            DateTime dateInput = DateTime.ParseExact(dateTested, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);

            string filePath = @"D:\UNI\Anul2\Semestrul2\CNA\CNATema2\GrpcServer\GrpcServer\Services\zodii.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                listZodiacSigns.Add(new ZodiacSigns(words[0], words[1], words[2], words[3], words[4]));
            }

            int size = listZodiacSigns.Count;
            for (int i = 0; i < size; ++i)
            {
                if (dateInput.Month == Int32.Parse(listZodiacSigns[i].StartMonth)
                    && dateInput.Day >= Int32.Parse(listZodiacSigns[i].StartDay)
                    || dateInput.Month == Int32.Parse(listZodiacSigns[i].EndMonth)
                    && dateInput.Day <= Int32.Parse(listZodiacSigns[i].EndDay))
                {
                    return listZodiacSigns[i].Sign;
                }
            }

            return String.Empty;
        }

        public override Task<OperationResponse> ZodiacSignInfo(DOBRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.Data);
            var response = new OperationResponse();
            return Task.FromResult(new OperationResponse() { Message = verifyTest(request.Data) });
        }
    }
}
