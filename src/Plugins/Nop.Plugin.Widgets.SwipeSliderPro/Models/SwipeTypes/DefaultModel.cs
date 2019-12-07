using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SwipeSliderPro.Models
{
    public class DefaultModel
    {
        public bool NavigationArrow { get; set; }
        public int Pagination { get; set; }
        public int SpaceBetweenSlides { get; set; }
        public int SlidesPerView { get; set; }              
        public bool Loop { get; set; }                    
        public bool AutoPlay { get; set; }        
        public int AutoPlayDelay { get; set; }        
        public bool AutoPlayDisableOnInteraction { get; set; }
        public bool CenteredSlides{ get; set; }
        public int Effect { get; set; }
        public bool KeyboardEnabled { get; set; }
        public bool MouseWheel { get; set; }
        public bool AutoHeigh { get; set; }        
        public bool FreeMode { get; set; }
        public bool FreeMode_Sticky { get; set; }
        public bool GrabCursor { get; set; }
        public int SlidesPerColumn { get; set; }
        public int HashOrHistory_Navigation { get; set; }
        public string Breakpoints { get; set; }
    }

    public enum PaginationEnum
    {
        Off = 1,
        Normal_Mode = 2,
        Dynamic_Bullets = 3,
        Progress = 4,
        Fraction = 5,
    }
    public enum SlidesPerViewEnum
    {
        Off = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Auto = 5,
    }
    public enum SlidesPerColumnEnum
    {
        Off = 1,
        Two = 2,
        Three = 3,
        Four = 4,        
    }
    public enum EffectEnum
    {
        Slide = 1,
        Fade = 2,
        Flip = 3,        
    }
    public enum DirectionEnum
    {
        Horizontal = 1,
        Vertical = 2,        
    }
    public enum HashOrHistoryEnum
    {
        Off = 1,
        Hash = 2,
        History = 3,
    }
    public class DefaultModelBinder : IModelBinder
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