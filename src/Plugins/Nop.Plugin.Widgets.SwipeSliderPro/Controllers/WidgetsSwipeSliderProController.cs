using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.SwipeSliderPro.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Newtonsoft.Json;

namespace Nop.Plugin.Widgets.SwipeSliderPro.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsSwipeSliderProController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsSwipeSliderProController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService, 
            IPictureService pictureService,
            ISettingService settingService,
            IStoreContext storeContext)
        {
            this._localizationService = localizationService;
            this._notificationService = notificationService;
            this._permissionService = permissionService;
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._storeContext = storeContext;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var swipeSliderProSettings = _settingService.LoadSetting<SwipeSliderProSettings>(storeScope);
            var model = new ConfigurationModel
            {
                #region slides
                Picture1Id = swipeSliderProSettings.Picture1Id,
                Text1 = swipeSliderProSettings.Text1,
                Link1 = swipeSliderProSettings.Link1,
                AltText1 = swipeSliderProSettings.AltText1,

                Picture2Id = swipeSliderProSettings.Picture2Id,
                Text2 = swipeSliderProSettings.Text2,
                Link2 = swipeSliderProSettings.Link2,
                AltText2 = swipeSliderProSettings.AltText2,

                Picture3Id = swipeSliderProSettings.Picture3Id,
                Text3 = swipeSliderProSettings.Text3,
                Link3 = swipeSliderProSettings.Link3,
                AltText3 = swipeSliderProSettings.AltText3,

                Picture4Id = swipeSliderProSettings.Picture4Id,
                Text4 = swipeSliderProSettings.Text4,
                Link4 = swipeSliderProSettings.Link4,
                AltText4 = swipeSliderProSettings.AltText4,

                Picture5Id = swipeSliderProSettings.Picture5Id,
                Text5 = swipeSliderProSettings.Text5,
                Link5 = swipeSliderProSettings.Link5,
                AltText5 = swipeSliderProSettings.AltText5,

                Picture6Id = swipeSliderProSettings.Picture6Id,
                Text6 = swipeSliderProSettings.Text6,
                Link6 = swipeSliderProSettings.Link6,
                AltText6 = swipeSliderProSettings.AltText6,

                Picture7Id = swipeSliderProSettings.Picture7Id,
                Text7 = swipeSliderProSettings.Text7,
                Link7 = swipeSliderProSettings.Link7,
                AltText7 = swipeSliderProSettings.AltText7,

                Picture8Id = swipeSliderProSettings.Picture8Id,
                Text8 = swipeSliderProSettings.Text8,
                Link8 = swipeSliderProSettings.Link8,
                AltText8 = swipeSliderProSettings.AltText8,

                Picture9Id = swipeSliderProSettings.Picture9Id,
                Text9 = swipeSliderProSettings.Text9,
                Link9 = swipeSliderProSettings.Link9,
                AltText9 = swipeSliderProSettings.AltText9,
                #endregion
                SwipeType = swipeSliderProSettings.SwipeType,
                
                SwipeTypeSettings = swipeSliderProSettings.SwipeTypeSettings,


                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                #region slides                
                model.Picture1Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture1Id, storeScope);
                model.Text1_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text1, storeScope);
                model.Link1_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link1, storeScope);
                model.AltText1_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText1, storeScope);

                model.Picture2Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture2Id, storeScope);
                model.Text2_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text2, storeScope);
                model.Link2_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link2, storeScope);
                model.AltText2_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText2, storeScope);

                model.Picture3Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture3Id, storeScope);
                model.Text3_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text3, storeScope);
                model.Link3_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link3, storeScope);
                model.AltText3_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText3, storeScope);

                model.Picture4Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture4Id, storeScope);
                model.Text4_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text4, storeScope);
                model.Link4_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link4, storeScope);
                model.AltText4_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText4, storeScope);

                model.Picture5Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture5Id, storeScope);
                model.Text5_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text5, storeScope);
                model.Link5_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link5, storeScope);
                model.AltText5_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText5, storeScope);

                model.Picture6Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture6Id, storeScope);
                model.Text6_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text6, storeScope);
                model.Link6_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link6, storeScope);
                model.AltText6_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText6, storeScope);

                model.Picture7Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture7Id, storeScope);
                model.Text7_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text7, storeScope);
                model.Link7_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link7, storeScope);
                model.AltText7_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText7, storeScope);

                model.Picture8Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture8Id, storeScope);
                model.Text8_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text8, storeScope);
                model.Link8_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link8, storeScope);
                model.AltText8_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText8, storeScope);

                model.Picture9Id_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Picture9Id, storeScope);
                model.Text9_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Text9, storeScope);
                model.Link9_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.Link9, storeScope);
                model.AltText9_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.AltText9, storeScope);
                #endregion
                
                model.SwipeType_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.SwipeType, storeScope);

                model.SwipeTypeSettings_OverrideForStore = _settingService.SettingExists(swipeSliderProSettings, x => x.SwipeTypeSettings, storeScope);                

            }

            return View("~/Plugins/Widgets.SwipeSliderPro/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var swipeSliderProSettings = _settingService.LoadSetting<SwipeSliderProSettings>(storeScope);
            #region slides
            //get previous picture identifiers
            var previousPictureIds = new[] 
            {
                swipeSliderProSettings.Picture1Id,
                swipeSliderProSettings.Picture2Id,
                swipeSliderProSettings.Picture3Id,
                swipeSliderProSettings.Picture4Id,
                swipeSliderProSettings.Picture5Id,
                swipeSliderProSettings.Picture6Id,
                swipeSliderProSettings.Picture7Id,
                swipeSliderProSettings.Picture8Id,
                swipeSliderProSettings.Picture9Id
            };

            swipeSliderProSettings.Picture1Id = model.Picture1Id;
            swipeSliderProSettings.Text1 = model.Text1;
            swipeSliderProSettings.Link1 = model.Link1;
            swipeSliderProSettings.AltText1 = model.AltText1;

            swipeSliderProSettings.Picture2Id = model.Picture2Id;
            swipeSliderProSettings.Text2 = model.Text2;
            swipeSliderProSettings.Link2 = model.Link2;
            swipeSliderProSettings.AltText2 = model.AltText2;

            swipeSliderProSettings.Picture3Id = model.Picture3Id;
            swipeSliderProSettings.Text3 = model.Text3;
            swipeSliderProSettings.Link3 = model.Link3;
            swipeSliderProSettings.AltText3 = model.AltText3;

            swipeSliderProSettings.Picture4Id = model.Picture4Id;
            swipeSliderProSettings.Text4 = model.Text4;
            swipeSliderProSettings.Link4 = model.Link4;
            swipeSliderProSettings.AltText4 = model.AltText4;

            swipeSliderProSettings.Picture5Id = model.Picture5Id;
            swipeSliderProSettings.Text5 = model.Text5;
            swipeSliderProSettings.Link5 = model.Link5;
            swipeSliderProSettings.AltText5 = model.AltText5;

            swipeSliderProSettings.Picture6Id = model.Picture6Id;
            swipeSliderProSettings.Text6 = model.Text6;
            swipeSliderProSettings.Link6 = model.Link6;
            swipeSliderProSettings.AltText6 = model.AltText6;

            swipeSliderProSettings.Picture7Id = model.Picture7Id;
            swipeSliderProSettings.Text7 = model.Text7;
            swipeSliderProSettings.Link7 = model.Link7;
            swipeSliderProSettings.AltText7 = model.AltText7;

            swipeSliderProSettings.Picture8Id = model.Picture8Id;
            swipeSliderProSettings.Text8 = model.Text8;
            swipeSliderProSettings.Link8 = model.Link8;
            swipeSliderProSettings.AltText8 = model.AltText8;

            swipeSliderProSettings.Picture9Id = model.Picture9Id;
            swipeSliderProSettings.Text9 = model.Text9;
            swipeSliderProSettings.Link9 = model.Link9;
            swipeSliderProSettings.AltText9 = model.AltText9;
            #endregion
            swipeSliderProSettings.SwipeType = model.SwipeType;
            swipeSliderProSettings.SwipeTypeSettings = model.SwipeTypeSettings;
            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture1Id, model.Picture1Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text1, model.Text1_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link1, model.Link1_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText1, model.AltText1_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture2Id, model.Picture2Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text2, model.Text2_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link2, model.Link2_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText2, model.AltText2_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture3Id, model.Picture3Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text3, model.Text3_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link3, model.Link3_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText3, model.AltText3_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture4Id, model.Picture4Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text4, model.Text4_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link4, model.Link4_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText4, model.AltText4_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture5Id, model.Picture5Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text5, model.Text5_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link5, model.Link5_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText5, model.AltText5_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture6Id, model.Picture6Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text6, model.Text6_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link6, model.Link6_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText6, model.AltText6_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture7Id, model.Picture7Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text7, model.Text7_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link7, model.Link7_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText7, model.AltText7_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture8Id, model.Picture8Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text8, model.Text8_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link8, model.Link8_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText8, model.AltText8_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Picture9Id, model.Picture9Id_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Text9, model.Text9_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.Link9, model.Link9_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.AltText9, model.AltText9_OverrideForStore, storeScope, false);

            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.SwipeType, model.SwipeType_OverrideForStore, storeScope, false);
            
            _settingService.SaveSettingOverridablePerStore(swipeSliderProSettings, x => x.SwipeTypeSettings, model.SwipeTypeSettings_OverrideForStore, storeScope, false);
            

            //now clear settings cache
            _settingService.ClearCache();
            
            //get current picture identifiers
            var currentPictureIds = new[]
            {
                swipeSliderProSettings.Picture1Id,
                swipeSliderProSettings.Picture2Id,
                swipeSliderProSettings.Picture3Id,
                swipeSliderProSettings.Picture4Id,
                swipeSliderProSettings.Picture5Id,
                swipeSliderProSettings.Picture6Id,
                swipeSliderProSettings.Picture7Id,
                swipeSliderProSettings.Picture8Id,
                swipeSliderProSettings.Picture9Id
            };

            //delete an old picture (if deleted or updated)
            foreach (var pictureId in previousPictureIds.Except(currentPictureIds))
            { 
                var previousPicture = _pictureService.GetPictureById(pictureId);
                if (previousPicture != null)
                    _pictureService.DeletePicture(previousPicture);
            }

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}