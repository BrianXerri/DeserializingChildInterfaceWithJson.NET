using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deserializer.Interfaces;
using Newtonsoft.Json.Converters;

namespace Deserializer.Converters
{
    public class ResultDataConverter : CustomCreationConverter<IResultData>
    {
        public Type ResultDataType { get; private set; }

        /// <summary>
        /// ResultDataConverter 
        /// </summary>
        /// <param name="reportDataType">Pass through the strong type for IResultData</param>
        public ResultDataConverter(Type reportDataType)
        {
            ResultDataType = reportDataType;
        }

        public override IResultData Create(Type objectType)
        {
            // Converts the anonymouse IResultData to the strong type defined in the constructor 
            return (IResultData)Activator.CreateInstance(ResultDataType);
        }
    }
}
