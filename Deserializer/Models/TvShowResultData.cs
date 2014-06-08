using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deserializer.Interfaces;

namespace Deserializer.Models
{
    public class TvShowResultData : IResultData 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Network { get; set; }
        public int Series { get; set; }
        public int Episodes { get; set; } 
    }
}
