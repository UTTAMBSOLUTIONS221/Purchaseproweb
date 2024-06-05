using Newtonsoft.Json;
using Purchaseproweb.Entities;
using Purchaseproweb.Enum;
using Purchaseproweb.Models;
using System.Text;

namespace Purchaseproweb.Services
{
    public class Wemanageservices
    {
        string BaseUrl = "";
        public Wemanageservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
        }
        #region User Management
        public async Task<UsermodelResponce> Validateuser(Userloginmodel obj)
        {
            UsermodelResponce userModel = new UsermodelResponce { };
            var resp = await POSTTOAPILOGIN(BaseUrl + "/api/AccountManagement/Authenticate", obj);
            if (resp.Respstatus == 200)
            {
                userModel = new UsermodelResponce
                {
                    Token = resp.Token,
                    Usermodel = resp.Usermodel,
                    Respstatus = resp.Respstatus,
                    RespMessage = resp.RespMessage,
                };
            }
            else
            {
                userModel.Respstatus = 401;
                userModel.RespMessage = "Incorrect Password!";
            }

            return userModel;
        }

        public async Task<Genericmodel> Resetuserpasswordpost(Staffresetpassword obj)
        {
            Genericmodel resp = new Genericmodel();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + "/api/AccountManagement/Authenticate", content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Genericmodel>(outPut);
                }
            }
            return resp;
        }
        public async Task<UsermodelResponce> Forgotpasswordpost(Staffforgotpassword obj)
        {
            UsermodelResponce resp = new UsermodelResponce();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + "/api/AccountManagement/Forgotuserpasswordpost", content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<UsermodelResponce>(outPut);
                }
            }
            return resp;
        }
        #endregion


        #region System Permissions

        public async Task<IEnumerable<Systempermissions>> Getsystempermissiondata(string Tokenbearer)
        {
            IEnumerable<Systempermissions> Data = new List<Systempermissions>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystempermissiondata"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<Systempermissions>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Registersystempermissiondata(string Tokenbearer, Systempermissions obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/Maintenance/Registersystempermissiondata", obj);
            return resp;
        }

        public async Task<Systempermissions> Getsystempermissiondatabyid(string Tokenbearer, long Permissionid)
        {
            Systempermissions Data = new Systempermissions();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystempermissiondatabyid/" + Permissionid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Systempermissions>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region System Vehicle Makes

        public async Task<IEnumerable<Systemvehiclemakes>> Getsystemvehiclemakedata(string Tokenbearer)
        {
            IEnumerable<Systemvehiclemakes> Data = new List<Systemvehiclemakes>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemvehiclemakedata"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<Systemvehiclemakes>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Registersystemvehiclemakedata(string Tokenbearer, Systemvehiclemakes obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/Maintenance/Registersystemvehiclemakedata", obj);
            return resp;
        }

        public async Task<Systemvehiclemakes> Getsystemvehiclemakedatabyid(string Tokenbearer, long Vehiclemakeid)
        {
            Systemvehiclemakes Data = new Systemvehiclemakes();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemvehiclemakedatabyid/" + Vehiclemakeid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Systemvehiclemakes>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region System Vehicle Models

        public async Task<IEnumerable<Systemvehiclemodeldata>> Getsystemvehiclemodeldata(string Tokenbearer)
        {
            IEnumerable<Systemvehiclemodeldata> Data = new List<Systemvehiclemodeldata>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemvehiclemodeldata"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<Systemvehiclemodeldata>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Registersystemvehiclemodeldata(string Tokenbearer, Systemvehiclemodels obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/Maintenance/Registersystemvehiclemodeldata", obj);
            return resp;
        }

        public async Task<Systemvehiclemodels> Getsystemvehiclemodeldatabyid(string Tokenbearer, long Vehiclemodelid)
        {
            Systemvehiclemodels Data = new Systemvehiclemodels();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemvehiclemodeldatabyid/" + Vehiclemodelid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Systemvehiclemodels>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region System Customers
        public async Task<IEnumerable<Systemcustomerdatamodel>> Getsystemcustomerdata(string Tokenbearer, long TenantId)
        {
            IEnumerable<Systemcustomerdatamodel> Data = new List<Systemcustomerdatamodel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/Getsystemcustomers/" + TenantId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<Systemcustomerdatamodel>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Addsystemcustomerdata(string Tokenbearer, Systemcustomerdetail obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/Registersystemcustomer", obj);
            return resp;
        }
        public async Task<Systemcustomerdetail> Getsystemcustomerdatabyid(string Tokenbearer, long? CustomerId)
        {
            Systemcustomerdetail Obj = new Systemcustomerdetail();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/Getsystemcustomerdetaildata/" + CustomerId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<Systemcustomerdetail>(apiResponse);
                }
            }
            return Obj;
        }
        public async Task<Genericmodel> Createsystemcustomeruserdata(string Tokenbearer, Systemcustomerdetail obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/Registersystemcustomeruserdata", obj);
            return resp;
        }
        public async Task<Systemcustomerdetaildatamodel> Getsystemcustomerloandetaildata(string Tokenbearer, long? CustomerId)
        {
            Systemcustomerdetaildatamodel Obj = new Systemcustomerdetaildatamodel();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/Getsystemcustomerloandetaildata/" + CustomerId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<Systemcustomerdetaildatamodel>(apiResponse);
                }
            }
            return Obj;
        }
        #endregion

        #region System Tenant Staffs
        public async Task<IEnumerable<SystemStaffModel>> Getsystemstaffdata(string Tokenbearer, long TenantId)
        {
            IEnumerable<SystemStaffModel> Data = new List<SystemStaffModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StaffManagement/Getsystemstaffsdata/" + TenantId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<SystemStaffModel>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Addsystemstaffdata(string Tokenbearer, Systemstaffs obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/StaffManagement/Registersystemtaff", obj);
            return resp;
        }
        public async Task<Systemstaffs> Getsystemstaffdatabyid(string Tokenbearer, long? TenantStaffId)
        {
            Systemstaffs Obj = new Systemstaffs();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StaffManagement/Getsystemstaffdatabyid/" + TenantStaffId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Obj = JsonConvert.DeserializeObject<Systemstaffs>(apiResponse);
                }
            }
            return Obj;
        }
        public async Task<Genericmodel> Resendstaffpassword(string Tokenbearer, long TenantStaffId)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/AccountManagement/Resendstaffpassword/" + TenantStaffId, null);
            return resp;
        }
        #endregion

        #region System Roles
        public async Task<IEnumerable<SystemUserRoles>> GetSystemUserRolesData(string Tokenbearer)
        {
            IEnumerable<SystemUserRoles> Data = new List<SystemUserRoles>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StaffManagement/Getsystemroles"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<SystemUserRoles>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Addsystemroledata(string Tokenbearer, Systemuserroledetail obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/StaffManagement/Registersystemstaffrole", obj);
            return resp;
        }
        public async Task<Systemuserroledetail> GetSystemRoleDetailData(string Tokenbearer, long? RoleId)
        {
            Systemuserroledetail Role = new Systemuserroledetail();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StaffManagement/Getsystemroledetaildata/" + RoleId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Role = JsonConvert.DeserializeObject<Systemuserroledetail>(apiResponse);
                }
            }
            return Role;
        }
        #endregion

        #region System Tenant

        public async Task<IEnumerable<Systemtenantdatamodel>> Getsystemtenantdata(string Tokenbearer)
        {
            IEnumerable<Systemtenantdatamodel> Data = new List<Systemtenantdatamodel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemtenantdata"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<Systemtenantdatamodel>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Registersystemtenantdata(string Tokenbearer, Systemtenants obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/Maintenance/Registersystemtenantdata", obj);
            return resp;
        }

        public async Task<Systemtenants> Getsystemtenantdatabyid(string Tokenbearer, long TenantId)
        {
            Systemtenants Data = new Systemtenants();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemtenantdatabyid/" + TenantId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Systemtenants>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region Tenant Assets

        public async Task<IEnumerable<Systemassetdatamodel>> Getsystemassetsdata(string Tokenbearer)
        {
            IEnumerable<Systemassetdatamodel> Data = new List<Systemassetdatamodel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemassetsdata"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<Systemassetdatamodel>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Registersystemassetdata(string Tokenbearer, Systemassets obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/Maintenance/Registersystemassetdata", obj);
            return resp;
        }

        public async Task<Systemassets> Getsystemassetdatabyid(string Tokenbearer, long AssetId)
        {
            Systemassets Data = new Systemassets();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/Maintenance/Getsystemassetdatabyid/" + AssetId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Systemassets>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region System Customer Loan
        public async Task<Genericmodel> Addsystemcustomerloandata(string Tokenbearer, Customerloandetailsdata obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/Registersystemcustomerloandetail", obj);
            return resp;
        }
        public async Task<PayResponse> Payloaninvoiceitemdata(string Tokenbearer, PesaAppRequestData obj)
        {
            var resp = await POSTPAYMENTTOAPI(Tokenbearer, "/api/CustomerManagement/Expresspayloaninvoiceitemdata", obj);
            return resp;
        }
        public async Task<PayResponse> Confirmmpesatransactionhasbeenrecieved(string Tokenbearer, PaymentNotificationData obj)
        {
            var resp = await POSTPAYMENTTOAPI(Tokenbearer, "/api/CustomerManagement/Expresspayloaninvoiceitemdata", obj);
            return resp;
        }
        #endregion

        #region Customer Summary Reports
        public async Task<Systemreportdataandparameters> Generatecustomerloanpaymentdata(string Tokenbearer,long TenantId, DateTime Startdate, DateTime Enddate,long Customerid,long Assetdetailid, long Loanstatus)
        {
            Systemreportdataandparameters Data = new Systemreportdataandparameters();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/ReportManagement/Generatesystemloanrepaymentdata/" + TenantId + "/" + Customerid + "/" + Assetdetailid + "/" + Loanstatus + "/" + Startdate.ToString("yyyy-MM-dd") + "/" + Enddate.ToString("yyyy-MM-dd")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Systemreportdataandparameters>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region Delete,Deactivate Actions
        public async Task<Genericmodel> DeactivateorDeleteTableColumnData(string Tokenbearer, ActivateDeactivateActions model)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/DeactivateorDeleteTableColumnData", model);
            return resp;
        }
        public async Task<Genericmodel> RemoveTableColumnData(string Tokenbearer, ActivateDeactivateActions model)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/RemoveTableColumnData", model);
            return resp;
        }
        #endregion


        #region Other Methods
        public async Task<UsermodelResponce> AUTHPOSTTOAPILOGIN(string endpoint, dynamic obj)
        {
            UsermodelResponce resp = new UsermodelResponce();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<UsermodelResponce>(outPut);
                }
            }
            return resp;
        }
        public async Task<UsermodelResponce> POSTTOAPILOGIN(string endpoint, dynamic obj)
        {
            UsermodelResponce resp = new UsermodelResponce();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<UsermodelResponce>(outPut);
                }
            }
            return resp;
        }
        public async Task<Genericmodel> POSTTOAPI(string Tokenbearer, string endpoint, dynamic obj)
        {
            Genericmodel resp = new Genericmodel();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Genericmodel>(outPut);
                }
            }
            return resp;
        }
        public async Task<PayResponse> POSTPAYMENTTOAPI(string Tokenbearer, string endpoint, dynamic obj)
        {
            PayResponse resp = new PayResponse();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<PayResponse>(outPut);
                }
            }
            return resp;
        }
        public async Task<List<ListModel>> GetSystemDropDownData(string Tokenbearer, ListModelType listType)
        {
            List<ListModel> list = new List<ListModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/GeneralManagement/Systemdropdowns?listType=" + (int)listType))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<ListModel>>(apiResponse);
                }
            }
            return list;
        }
        public async Task<List<ListModel>> Getsystemdropdowndatabyid(string Tokenbearer, ListModelType listType, long Id)
        {
            List<ListModel> list = new List<ListModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/GeneralManagement/SystemdropdownbyId/" + Id + "?listType=" + (int)listType))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<ListModel>>(apiResponse);
                }
            }
            return list;
        }
        #endregion

        

    }
}
