using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deserializer.Interfaces;

namespace Deserializer.Models
{
    public class MovieResultData : IResultData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Studio { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
