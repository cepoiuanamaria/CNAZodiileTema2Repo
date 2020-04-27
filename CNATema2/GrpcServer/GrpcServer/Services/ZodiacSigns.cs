using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class ZodiacSigns
    {
        private string _zodiacSign;
        private string _startDay;
        private string _startMonth;
        private string _endDay;
        private string _endMonth;
        public ZodiacSigns(string sign, string startDay, string startMonth, string endDay, string endMonth)
        {
            _zodiacSign = sign;
            _startDay = startDay;
            _startMonth = startMonth;
            _endDay = endDay;
            _endMonth = endMonth;
        }
        
        public string Sign
        {
            get { return _zodiacSign; }
        }
        public string StartDay
        {
            get { return _startDay; }
        }
        public string StartMonth
        {
            get { return _startMonth; }
        }
        public string EndDay
        {
            get { return _endDay; }
        }
        public string EndMonth
        {
            get { return _endMonth; }
        }
    }
}
