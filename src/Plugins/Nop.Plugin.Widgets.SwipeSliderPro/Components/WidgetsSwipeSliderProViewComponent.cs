using System;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.SwipeSliderPro.Infrastructure.Cache;
using Nop.Plugin.Widgets.SwipeSliderPro.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.SwipeSliderPro.Components
{
    [ViewComponent(Name = "WidgetsSwipeSliderPro")]
    public class WidgetsNivoSliderViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsNivoSliderViewComponent(IStoreContext storeContext, 
            IStaticCacheManager cacheManager, 
            ISettingService settingService, 
            IPictureService pictureService,
            IWebHelper webHelper)
        {
            _storeContext = storeContext;
            _cacheManager = cacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var swipeSliderProSettings = _settingService.LoadSetting<SwipeSliderProSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                Picture1Url = GetPictureUrl(swipeSliderProSettings.Picture1Id),
                Text1 = swipeSliderProSettings.Text1,
                Link1 = swipeSliderProSettings.Link1,
                AltText1 = swipeSliderProSettings.AltText1,

                Picture2Url = GetPictureUrl(swipeSliderProSettings.Picture2Id),
                Text2 = swipeSliderProSettings.Text2,
                Link2 = swipeSliderProSettings.Link2,
                AltText2 = swipeSliderProSettings.AltText2,

                Picture3Url = GetPictureUrl(swipeSliderProSettings.Picture3Id),
                Text3 = swipeSliderProSettings.Text3,
                Link3 = swipeSliderProSettings.Link3,
                AltText3 = swipeSliderProSettings.AltText3,

                Picture4Url = GetPictureUrl(swipeSliderProSettings.Picture4Id),
                Text4 = swipeSliderProSettings.Text4,
                Link4 = swipeSliderProSettings.Link4,
                AltText4 = swipeSliderProSettings.AltText4,

                Picture5Url = GetPictureUrl(swipeSliderProSettings.Picture5Id),
                Text5 = swipeSliderProSettings.Text5,
                Link5 = swipeSliderProSettings.Link5,
                AltText5 = swipeSliderProSettings.AltText5,

                Picture6Url = GetPictureUrl(swipeSliderProSettings.Picture6Id),
                Text6 = swipeSliderProSettings.Text6,
                Link6 = swipeSliderProSettings.Link6,
                AltText6 = swipeSliderProSettings.AltText6,

                Picture7Url = GetPictureUrl(swipeSliderProSettings.Picture7Id),
                Text7 = swipeSliderProSettings.Text7,
                Link7 = swipeSliderProSettings.Link7,
                AltText7 = swipeSliderProSettings.AltText7,

                Picture8Url = GetPictureUrl(swipeSliderProSettings.Picture8Id),
                Text8 = swipeSliderProSettings.Text8,
                Link8 = swipeSliderProSettings.Link8,
                AltText8 = swipeSliderProSettings.AltText8,

                Picture9Url = GetPictureUrl(swipeSliderProSettings.Picture9Id),
                Text9 = swipeSliderProSettings.Text9,
                Link9 = swipeSliderProSettings.Link9,
                AltText9 = swipeSliderProSettings.AltText9,

                SwipeType = swipeSliderProSettings.SwipeType,
                CoverflowEffect3D = swipeSliderProSettings.CoverflowEffect3D
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url) && string.IsNullOrEmpty(model.Picture6Url) &&
                string.IsNullOrEmpty(model.Picture7Url) && string.IsNullOrEmpty(model.Picture8Url) &&
                string.IsNullOrEmpty(model.Picture9Url))
                //no pictures uploaded
                return Content("");

            switch (model.SwipeType)
            {
                case (int) SwipeTypeEnum.CoverflowEffect3d:
                    return View("~/Plugins/Widgets.SwipeSliderPro/Views/SwipeTypes/CoverflowEffect3DPublicInfo.cshtml", model);                    
                default:
                    return View("~/Plugins/Widgets.SwipeSliderPro/Views/PublicInfo.cshtml", model);                    
            }
            
        }

        protected string GetPictureUrl(int pictureId)
        {
            var cacheKey = string.Format(ModelCacheEventConsumer.PICTURE_URL_MODEL_KEY, 
                pictureId, _webHelper.IsCurrentConnectionSecured() ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);

            return _cacheManager.Get(cacheKey, () =>
            {
                //little hack here. nulls aren't cacheable so set it to ""
                var url = _pictureService.GetPictureUrl(pictureId, showDefaultPicture: false) ?? "";
                return url;
            });
        }
    }
}
