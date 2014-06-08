using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deserializer.Interfaces;

namespace Deserializer.Models
{
    public class ResultWrapper
    {
        // Generic Meta Data
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime Requested { get; set; }
        public DateTime Sent { get; set; }

        // Result Data
        public List<IResultData> ResultData { get; set; }
    }
}
