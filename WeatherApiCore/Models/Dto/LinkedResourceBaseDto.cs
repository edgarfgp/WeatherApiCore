using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Models.Dto
{
    public abstract class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();

    }
}
