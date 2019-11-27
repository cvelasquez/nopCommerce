using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.SwipeSliderPro.SwipeTypes
{
    public class CoverflowEffect3D : ISettings
    {
        public bool loop { get; set; }
        public bool freeMode { get; set; }
        public bool autoPlay { get; set; }
        public int autoPlayDelay { get; set; }
        public bool autoPlayDisableOnInteraction { get; set; }
    }

    public enum AspectRelation
    {
        Books,
        Music
    }
}