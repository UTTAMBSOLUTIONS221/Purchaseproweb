using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Purchaseproweb.Entities;
using Purchaseproweb.Enum;
using Purchaseproweb.Services;

namespace Purchaseproweb.Controllers
{
    [Authorize]
    public class StaffManagementController : BaseController
    {
        private readonly Wemanageservices bl;
        public StaffManagementController(IConfiguration config)
        {
            bl = new Wemanageservices(config);
        }
        #region System Staffs
        [HttpGet]
        public async Task<IActionResult> Systemstaffslist()
        {
            var data = await bl.Getsystemstaffdata(SessionUserData.Token, SessionUserData.Usermodel.Tenantid);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemstaff(long? Tenantstaffid)
        {
            Systemstaffs model = new Systemstaffs();
            ViewData["Systemroleslists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Roles).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            ViewData["Systemphonecodelists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Phonecodes).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            if (Tenantstaffid > 0)
            {
                model = await bl.Getsystemstaffdatabyid(SessionUserData.Token, Tenantstaffid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemstaffdata(Systemstaffs model)
        {
            var Resp = await bl.Addsystemstaffdata(SessionUserData.Token, model);
            return Json(Resp);
        }
        [HttpGet, HttpPost]
        public async Task<IActionResult> Resendstaffpassword(long Tenantstaffid)
        {
            var Resp = await bl.Resendstaffpassword(SessionUserData.Token, Tenantstaffid);
            if (Resp.RespStatus == 0)
            {
                Success(Resp.RespMessage, true);
            }
            else if (Resp.RespStatus == 1)
            {
                Warning(Resp.RespMessage, true);
            }
            else
            {
                Danger(Resp.RespMessage, true);
            }
            return RedirectToAction("Systemstaffslist");
        }
        #endregion

        #region System Roles
        [HttpGet]
        public async Task<IActionResult> Rolelist()
        {
            var data = await bl.GetSystemUserRolesData(SessionUserData.Token);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemrole(long RoleId)
        {
            Systemuserroledetail model = new Systemuserroledetail();
            ViewData["Systempermissionlists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Permissions).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            if (RoleId > 0)
            {
                model = await bl.GetSystemRoleDetailData(SessionUserData.Token, RoleId);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemroledata(Systemuserroledetail model)
        {
            var Resp = await bl.Addsystemroledata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion
    }
}
