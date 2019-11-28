using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.SwipeSliderPro.Models
{
    public class CoverflowEffect3D : BaseNopModel
    {
        public bool Loop { get; set; }
        public bool Loop_OverrideForStore { get; set; }
        public bool FreeMode { get; set; }
        public bool FreeMode_OverrideForStore { get; set; }
        public bool AutoPlay { get; set; }
        public bool AutoPlay_OverrideForStore { get; set; }
        public int AutoPlayDelay { get; set; }
        public bool AutoPlayDelay_OverrideForStore { get; set; }
        public bool AutoPlayDisableOnInteraction { get; set; }
        public bool AutoPlayDisableOnInteraction_OverrideForStore { get; set; }
        public int AspectRelation {get; set;}
        public bool AspectRelation_OverrideForStore { get; set; }
    }

    public enum AspectRelation
    {
        Books_Movies = 1,
        Music_Apps = 2
    }
}