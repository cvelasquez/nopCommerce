using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using Newtonsoft.Json;
using Nop.Plugin.Widgets.SwipeSliderPro.Models;

namespace Nop.Plugin.Widgets.SwipeSliderPro
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class SwipeSliderPro : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public SwipeSliderPro(ILocalizationService localizationService,
            IPictureService pictureService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider)
        {
            _localizationService = localizationService;
            _pictureService = pictureService;
            _settingService = settingService;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomepageTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsSwipeSliderPro/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsSwipeSliderPro";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Widgets.SwipeSliderPro/Content/swipesliderpro/sample-images/");

            //settings
            var settings = new SwipeSliderProSettings
            {
                Picture1Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-1.jpg")), MimeTypes.ImagePJpeg, "nature-1").Id,
                Picture2Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-2.jpg")), MimeTypes.ImagePJpeg, "nature-2").Id,
                Picture3Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-3.jpg")), MimeTypes.ImagePJpeg, "nature-3").Id,
                Picture4Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-4.jpg")), MimeTypes.ImagePJpeg, "nature-4").Id,
                Picture5Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-5.jpg")), MimeTypes.ImagePJpeg, "nature-5").Id,
                Picture6Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-6.jpg")), MimeTypes.ImagePJpeg, "nature-6").Id,
                Picture7Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-7.jpg")), MimeTypes.ImagePJpeg, "nature-7").Id,
                Picture8Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-8.jpg")), MimeTypes.ImagePJpeg, "nature-8").Id,
                Picture9Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(_fileProvider.Combine(sampleImagesPath, "nature-9.jpg")), MimeTypes.ImagePJpeg, "nature-9").Id,
                SwipeType = 1, //Default                
                SwipeTypeSettings = JsonConvert.SerializeObject(new DefaultModel() { 
                    Pagination = (int)PaginationEnum.Normal_Mode,Effect = (int)EffectEnum.Fade,
                    AutoPlay = true, AutoPlayDelay = 2500, Loop = true, GrabCursor = true })
            };
            _settingService.SaveSetting(settings);
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Picture", "Picture");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Picture.Hint", "Upload picture.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Text", "Comment");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Text.Hint", "Enter comment for picture. Leave empty if you don't want to display any text.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Link", "URL");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Link.Hint", "Enter URL. Leave empty if you don't want this picture to be clickable.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.AltText", "Image alternate text");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.AltText.Hint", "Enter alternate text that will be added to image.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.SwipeType", "Swipe Slider Type");
            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<SwipeSliderProSettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Picture");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Picture.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Text");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Text.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Link");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.Link.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.AltText");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.AltText.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.SwipeSliderPro.SwipeType");
            base.Uninstall();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}