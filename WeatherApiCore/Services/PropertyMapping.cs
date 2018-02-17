using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.IServices;

namespace WeatherApiCore.IServices
{
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public Dictionary<string, PropertyMappingValue> mappingDictionary { get; private set; }
        public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            this.mappingDictionary = mappingDictionary;
        }
    }
}
