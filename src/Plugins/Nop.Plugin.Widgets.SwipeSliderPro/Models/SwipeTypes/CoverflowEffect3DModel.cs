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

    public enum AspectRelationEnum
    {
        Rectangle_Books_Movies = 1,
        Square_Music_Apps = 2
    }
    public class CoverflowEffect3DModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            var loop = bindingContext.HttpContext.Request.Form.ContainsKey("cover.Loop")?bindingContext.HttpContext.Request.Form["cover.Loop"][0]:null;            
            var freeMode = bindingContext.HttpContext.Request.Form.ContainsKey("cover.Freemode") ? bindingContext.HttpContext.Request.Form["cover.Freemode"][0] : null;
            var autoPlay = bindingContext.HttpContext.Request.Form.ContainsKey("cover.AutoPlay") ? bindingContext.HttpContext.Request.Form["cover.AutoPlay"][0] : null;
            var autoPlayDelay = bindingContext.HttpContext.Request.Form.ContainsKey("cover.AutoPlayDelay") ? bindingContext.HttpContext.Request.Form["cover.AutoPlayDelay"][0] : null;
            var autoPlayDisableOnInteraction = bindingContext.HttpContext.Request.Form.ContainsKey("cover.AutoPlayDisableOnInteraction") ? bindingContext.HttpContext.Request.Form["cover.AutoPlayDisableOnInteraction"][0] : null;
            var aspectRelation = bindingContext.HttpContext.Request.Form.ContainsKey("cover.AspectRelation") ? bindingContext.HttpContext.Request.Form["cover.AspectRelation"][0] : null;

            CoverflowEffect3DModel cover = new CoverflowEffect3DModel() {                                  
                Loop = Convert.ToBoolean(loop),                
                FreeMode = Convert.ToBoolean(freeMode),
                AutoPlay = Convert.ToBoolean(autoPlay),
                AutoPlayDelay = Convert.ToInt32(autoPlayDelay),
                AutoPlayDisableOnInteraction = Convert.ToBoolean(autoPlayDisableOnInteraction),
                AspectRelation = Convert.ToInt32(aspectRelation),
            };
            var result = JsonConvert.SerializeObject(cover);

            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}