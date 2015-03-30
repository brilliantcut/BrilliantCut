﻿
using EPiTube.FacetFilter.Core.FilterSettings;

namespace EPiTube.facetFilter.Core.DataAnnotation
{
    public class SliderFilterAttribute : FacetFilterAttribute
    {
        public SliderFilterAttribute()
            : this(0, 100)
        {
            
        }

        public SliderFilterAttribute(int min, int max)
        {
            Setting = new SliderFilterSetting();
        }
    }
}