using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum.Models
{
    public class PlantProperties
    {       [Display(ResourceType = typeof(App_GlobalResources.Teksten), Name= "LabelPrijs")]
            [Range(0, 1000,ErrorMessageResourceType=typeof(App_GlobalResources.Teksten), ErrorMessageResourceName="RangePrijs")]
            public decimal VerkoopPrijs { get; set; }
       
    }
}