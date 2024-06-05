using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Purchaseproweb.Entities;
using Purchaseproweb.Enum;
using Purchaseproweb.Models;
using Purchaseproweb.Services;

namespace Purchaseproweb.Controllers
{
    [Authorize]
    public class MaintenanceController : BaseController
    {
        private readonly Wemanageservices bl;
        public MaintenanceController(IConfiguration config)
        {
            bl = new Wemanageservices(config);
        }

        #region System Permissions
        public async Task<IActionResult> Systempermissionlist()
        {
            var data = await bl.Getsystempermissiondata(SessionUserData.Token);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystempermissions(long Permissionid)
        {
            Systempermissions model = new Systempermissions();
            if (Permissionid > 0)
            {
                model = await bl.Getsystempermissiondatabyid(SessionUserData.Token, Permissionid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystempermissiondata(Systempermissions model)
        {
            var Resp = await bl.Registersystempermissiondata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion

        #region System Vehicle Makes
        public async Task<IActionResult> Systemvehiclemakelist()
        {
            var data = await bl.Getsystemvehiclemakedata(SessionUserData.Token);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemvehiclemakes(long Vehiclemakeid)
        {
            Systemvehiclemakes model = new Systemvehiclemakes();
            if (Vehiclemakeid > 0)
            {
                model = await bl.Getsystemvehiclemakedatabyid(SessionUserData.Token, Vehiclemakeid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemvehiclemakedata(Systemvehiclemakes model)
        {
            var Resp = await bl.Registersystemvehiclemakedata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion

        #region System Vehicle Model
        public async Task<IActionResult> Systemvehiclemodellist()
        {
            var data = await bl.Getsystemvehiclemodeldata(SessionUserData.Token);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemvehiclemodels(long Vehiclemodelid)
        {
            ViewData["Systemvehiclemakeslists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Vehiclemakes).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            Systemvehiclemodels model = new Systemvehiclemodels();
            if (Vehiclemodelid > 0)
            {
                model = await bl.Getsystemvehiclemodeldatabyid(SessionUserData.Token, Vehiclemodelid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemvehiclemodeldata(Systemvehiclemodels model)
        {
            var Resp = await bl.Registersystemvehiclemodeldata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion

        #region System Tenants 
        public async Task<IActionResult> Systemtenantlist()
        {
            var data = await bl.Getsystemtenantdata(SessionUserData.Token);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemtenants(long Tenantid)
        {
            Systemtenants model = new Systemtenants();
            if (Tenantid > 0)
            {
                model = await bl.Getsystemtenantdatabyid(SessionUserData.Token, Tenantid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemtenantdata(Systemtenants model)
        {
            var Resp = await bl.Registersystemtenantdata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion

        #region System Assets 
        public async Task<IActionResult> Systemassetlist()
        {
            var data = await bl.Getsystemassetsdata(SessionUserData.Token);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemassets(long Assetid)
        {
            Systemassets model = new Systemassets();
            if (Assetid > 0)
            {
                model = await bl.Getsystemassetdatabyid(SessionUserData.Token, Assetid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemassetdata(Systemassets model)
        {
            var Resp = await bl.Registersystemassetdata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion
    }
}
