using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitorWPFApp.Models
{
    public class SensorData
    {
        public DateTime Date { get; set; }
        public ushort Value { get; set; }

        public SensorData(DateTime date, ushort value)
        {
            Date = date;
            Value = value;
        }
    }
}
