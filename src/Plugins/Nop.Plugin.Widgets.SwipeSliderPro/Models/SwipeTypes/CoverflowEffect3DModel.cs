using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SwipeSliderPro.Models
{
    public class CoverflowEffect3DModel
    {
        public bool Loop { get; set; }        
        public bool FreeMode { get; set; }        
        public bool AutoPlay { get; set; }        
        public int AutoPlayDelay { get; set; }        
        public bool AutoPlayDisableOnInteraction { get; set; }        
        public int AspectRelation {get; set;}        
    }    
}