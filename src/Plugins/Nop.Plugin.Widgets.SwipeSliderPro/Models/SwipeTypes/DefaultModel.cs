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
        public bool AutoHeight { get; set; }        
        public bool FreeMode { get; set; }
        public bool FreeMode_Sticky { get; set; }
        public bool GrabCursor { get; set; }
        public int SlidesPerColumn { get; set; }
        public int HashOrHistory_Navigation { get; set; }
        public string Breakpoints { get; set; }
        public int AspectRelation { get; set; }
    }

    public enum PaginationEnum
    {
        Off = 0,
        Normal_Mode = 1,
        Dynamic_Bullets = 2,
        Progress = 3,
        Fraction = 4,
    }
    public enum SlidesPerViewEnum
    {
        Off = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Auto = 5,
    }
    public enum SlidesPerColumnEnum
    {
        Off = 0,
        Two = 2,
        Three = 3,
        Four = 4,        
    }
    public enum EffectEnum
    {
        Slide = 0,
        Fade = 1,
        Flip = 2,        
    }
    public enum DirectionEnum
    {
        Horizontal = 0,
        Vertical = 1,        
    }
    public enum HashOrHistoryEnum
    {
        None = 0,
        Hash = 1,
        History = 2,
    }
    public enum AspectRelationEnum
    {
        Square_Music_Apps = 0,
        Rectangle_Books_Movies = 1,        
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
            var autoheight = bindingContext.HttpContext.Request.Form.ContainsKey("cover.AutoHeight") ? bindingContext.HttpContext.Request.Form["cover.AutoHeight"][0] : null;
            var pagination = bindingContext.HttpContext.Request.Form.ContainsKey("cover.Pagination") ? bindingContext.HttpContext.Request.Form["cover.Pagination"][0] : null;
            var centerSlides = bindingContext.HttpContext.Request.Form.ContainsKey("cover.CenteredSlides") ? bindingContext.HttpContext.Request.Form["cover.CenteredSlides"][0] : null;
            var effect = bindingContext.HttpContext.Request.Form.ContainsKey("cover.Effect") ? bindingContext.HttpContext.Request.Form["cover.Effect"][0] : null;
            var grabCursor = bindingContext.HttpContext.Request.Form.ContainsKey("cover.GrabCursor") ? bindingContext.HttpContext.Request.Form["cover.GrabCursor"][0] : null;
            var breakpoints = bindingContext.HttpContext.Request.Form.ContainsKey("cover.Breakpoints") ? bindingContext.HttpContext.Request.Form["cover.Breakpoints"][0] : null;
            var hashOrHistory = bindingContext.HttpContext.Request.Form.ContainsKey("cover.HashOrHistory_Navigation") ? bindingContext.HttpContext.Request.Form["cover.HashOrHistory_Navigation"][0] : null;
            var keyboardEnabled = bindingContext.HttpContext.Request.Form.ContainsKey("cover.KeyboardEnabled") ? bindingContext.HttpContext.Request.Form["cover.KeyboardEnabled"][0] : null;
            var mouseWheel = bindingContext.HttpContext.Request.Form.ContainsKey("cover.MouseWheel") ? bindingContext.HttpContext.Request.Form["cover.MouseWheel"][0] : null;
            var navigationArrow = bindingContext.HttpContext.Request.Form.ContainsKey("cover.NavigationArrow") ? bindingContext.HttpContext.Request.Form["cover.NavigationArrow"][0] : null;
            var slidesPerColumn = bindingContext.HttpContext.Request.Form.ContainsKey("cover.SlidesPerColumn") ? bindingContext.HttpContext.Request.Form["cover.SlidesPerColumn"][0] : null;
            var slidesPerView = bindingContext.HttpContext.Request.Form.ContainsKey("cover.SlidesPerView") ? bindingContext.HttpContext.Request.Form["cover.SlidesPerView"][0] : null;
            var spaceBetweenSlides = bindingContext.HttpContext.Request.Form.ContainsKey("cover.SpaceBetweenSlides") ? bindingContext.HttpContext.Request.Form["cover.SpaceBetweenSlides"][0] : null;
            var aspectRelation = bindingContext.HttpContext.Request.Form.ContainsKey("cover.AspectRelation") ? bindingContext.HttpContext.Request.Form["cover.AspectRelation"][0] : null;

            DefaultModel cover = new DefaultModel() {                                  
                Loop = Convert.ToBoolean(loop),                
                FreeMode = Convert.ToBoolean(freeMode),
                FreeMode_Sticky = Convert.ToBoolean(freeMode),
                AutoPlay = Convert.ToBoolean(autoPlay),
                AutoPlayDelay = Convert.ToInt32(autoPlayDelay),
                AutoPlayDisableOnInteraction = Convert.ToBoolean(autoPlayDisableOnInteraction),
                AutoHeight = Convert.ToBoolean(autoheight),
                Pagination = Convert.ToInt32(pagination),
                CenteredSlides = Convert.ToBoolean(centerSlides),
                Effect = Convert.ToInt32(effect),
                GrabCursor = Convert.ToBoolean(grabCursor),
                Breakpoints = Convert.ToString(breakpoints),
                HashOrHistory_Navigation = Convert.ToInt32(hashOrHistory),
                KeyboardEnabled = Convert.ToBoolean(keyboardEnabled),
                MouseWheel = Convert.ToBoolean(mouseWheel),
                NavigationArrow = Convert.ToBoolean(navigationArrow),
                SlidesPerColumn = Convert.ToInt32(slidesPerColumn),
                SlidesPerView = Convert.ToInt32(slidesPerView),
                SpaceBetweenSlides = Convert.ToInt32(spaceBetweenSlides),
                AspectRelation = Convert.ToInt32(aspectRelation)
            };
            var result = JsonConvert.SerializeObject(cover);

            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}