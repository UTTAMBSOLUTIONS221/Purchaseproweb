using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Purchaseproweb.Entities;
using Purchaseproweb.Enum;
using Purchaseproweb.Models;
using Purchaseproweb.Services;

namespace Purchaseproweb.Controllers
{
    [Authorize]
    public class CustomerManagementController : BaseController
    {
        private readonly Wemanageservices bl;
        public CustomerManagementController(IConfiguration config)
        {
            bl = new Wemanageservices(config);

        }
        public async Task<IActionResult> Index()
        {
            var model = await bl.Getsystemcustomerloandetaildata(SessionUserData.Token, SessionUserData.Usermodel.ParentId);
            return View(model);
        }
        #region Customers
        [HttpGet]
        public async Task<IActionResult> Customerlist()
        {
            var data = await bl.Getsystemcustomerdata(SessionUserData.Token, SessionUserData.Usermodel.Tenantid);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Addsystemcustomers(long Customerid)
        {
            ViewData["Systemphonecodelists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Phonecodes).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            Systemcustomerdetail model = new Systemcustomerdetail();
            if (Customerid > 0)
            {
                model = await bl.Getsystemcustomerdatabyid(SessionUserData.Token, Customerid);
            }
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemcustomerdata(Systemcustomerdetail model)
        {
            var Resp = await bl.Addsystemcustomerdata(SessionUserData.Token, model);
            return Json(Resp);
        }
        public async Task<JsonResult> Createsystemcustomeruser(ActivateDeactivateActions model)
        {
            Genericmodel Resp = new Genericmodel();
            var data = await bl.Getsystemcustomerdatabyid(SessionUserData.Token, model.Entryid);
            if (data != null)
            {
                Resp = await bl.Createsystemcustomeruserdata(SessionUserData.Token, data);
            }
            else
            {
                Resp.RespStatus = 1;
                Resp.RespMessage = "Customer not Found";
            }
            return Json(Resp);
        }
        [HttpGet]
        public async Task<IActionResult> Systemcustomerdetail(long Customerid)
        {
            var model = await bl.Getsystemcustomerloandetaildata(SessionUserData.Token, Customerid);
            return View(model);
        }

        #endregion

        #region Customer Loans data
        [HttpGet]
        public async Task<IActionResult> Addsystemcustomerloan(long Customerid)
        {
            ViewData["Systemvehiclemakeslists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Vehiclemakes).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            ViewData["Systemassetlists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Assets).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            Systemcustomerloandata model = new Systemcustomerloandata();
            model.Customerid = Customerid;
            return PartialView(model);
        }
        public async Task<JsonResult> Addsystemcustomerloandata(Customerloandetailsdata model)
        {
            var Resp = await bl.Addsystemcustomerloandata(SessionUserData.Token, model);
            return Json(Resp);
        }

        [HttpGet]
        public async Task<IActionResult> Payloaninvoiceitem(long AccountId, long AccountNumber, long LoanDetailId, long Loandetailitemid, decimal Paymentamount, string Phonenumber, string Assetnumber)
        {
            Systemcustomeraccounttopups model = new Systemcustomeraccounttopups();
            model.Phonenumber = Phonenumber;
            model.Assetnumber = Assetnumber;
            model.AccountId = AccountId;
            model.AccountNumber = AccountNumber;
            model.LoanDetailId = LoanDetailId;
            model.Loandetailitemid = Loandetailitemid;
            model.Paymentamount = Paymentamount;
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> Customerpayloaninvoiceitem(long AccountId, long AccountNumber, long LoanDetailId, long Loandetailitemid, decimal Paymentamount, string Phonenumber)
        {
            Systemcustomeraccounttopups model = new Systemcustomeraccounttopups();
            model.Phonenumber = Phonenumber;
            model.AccountId = AccountId;
            model.AccountNumber = AccountNumber;
            model.LoanDetailId = LoanDetailId;
            model.Loandetailitemid = Loandetailitemid;
            model.Paymentamount = Paymentamount;
            return PartialView(model);
        }
        public async Task<JsonResult> Payloaninvoiceitemdata(Systemcustomeraccounttopups data)
        {
            PesaAppRequestData model = new PesaAppRequestData
            {
                TimeStamp = data.TimeStamp,
                ServiceCode = data.ServiceCode,
                AccountNumber = data.Assetnumber,
                Data = new PesaAppRequestBody
                {
                    AccountTopupId = data.AccountTopupId,
                    FinanceTransactionId = data.FinanceTransactionId,
                    AccountId = data.AccountId,
                    AccountNumber = data.AccountNumber,
                    LoanDetailId = data.LoanDetailId,
                    Loandetailitemid = data.Loandetailitemid,
                    Phonenumber = data.Phonenumber,
                    Paymentamount = data.Paymentamount,
                    Recievedamount = data.Recievedamount,
                    ModeofPayment = data.ModeofPayment,
                    Paymentmemo = data.Paymentmemo,
                    Topupreference = data.Topupreference,
                    Createdby = data.Createdby,
                    DateCreated = data.DateCreated,
                }
            };
            var Resp = await bl.Payloaninvoiceitemdata(SessionUserData.Token, model);
            return Json(Resp);
        }
        #endregion


        [HttpPost]
        public async Task<JsonResult> Confirmmpesatransactionhasbeenrecieved(PaymentNotificationData data)
        {
            var Resp = await bl.Confirmmpesatransactionhasbeenrecieved(SessionUserData.Token, data);
            return Json(Resp);
        }


        #region Delete,Deactivate Actions
        public async Task<JsonResult> AllDeleteDeativateActions(ActivateDeactivateActions model)
        {
            var resp = await bl.DeactivateorDeleteTableColumnData(SessionUserData.Token, model);
            return Json(resp);
        }
        public async Task<JsonResult> AllRemoveDeativateActions(ActivateDeactivateActions model)
        {
            var resp = await bl.RemoveTableColumnData(SessionUserData.Token, model);
            return Json(resp);
        }
        #endregion


        #region drop down data
        [HttpGet]
        public JsonResult Getsystemdropdowndatabyid(long Id)
        {
            var Resp = bl.Getsystemdropdowndatabyid(SessionUserData.Token, ListModelType.Vehiclemodels, Id).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            return Json(Resp);
        }
        #endregion
    }
}
