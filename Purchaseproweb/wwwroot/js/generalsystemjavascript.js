function Savesystempermissiondetails() {
    var uil1 = {
        PermissionId: $('#Systempermissionid').val(), Permissionname: $('#Systempermissionnameid').val(), Isadmin: $('#Systempermissionisadminid').is(':checked')
};
    $.post("/Maintenance/Addsystempermissiondata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Permission details not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}
function Savesystemvehiclemakedetails() {
    var uil1 = {
        Vehiclemakeid: $('#Systemvehiclemakeid').val(), Vehiclemakename: $('#Systemvehiclemakenameid').val()
    };
    $.post("/Maintenance/Addsystemvehiclemakedata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Details not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}

function Savesystemvehiclemodeldetails() {
    var uil1 = {
        Vehiclemodelid: $('#Systemvehiclemodelid').val(), Vehiclemakeid: $('#Systemvehiclemakeid').val(), Vehiclemodelname: $('#Systemvehiclemodelnameid').val()
    };
    $.post("/Maintenance/Addsystemvehiclemodeldata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Details not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}

function Savesystemtenantdetails() {
    var uil1 = {
        Tenantid: $('#Systemtenantid').val(), Tenantname: $('#Systemtenantnameid').val(), Emailserver: $('#Systememailserverid').val(), Emailpassword: $('#Systememailpasswordid').val(),
        Shortcode: $('#Systemmpesashortcodeid').val(), Consumerkey: $('#Systemmpesaconsumerkeyid').val(), Consumersecret: $('#Systemmpesaconsumersecretid').val(), Tenantlipanampesapasskey: $('#Systemtenantlipanampesapasskeyid').val(), Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Maintenance/Addsystemtenantdata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("System tenant details  Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}

function Savesystemassetdetails() {
    var uil1 = {
        Assetid: $('#Systemassetid').val(), Assetname: $('#Systemassetnameid').val(), Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/Maintenance/Addsystemassetdata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("System assets details  Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}

function Savesystemcustomerdetails() {
    var uil1 = {
        Tenantid: $('#systemLoggedinedtenantid').val(), Customerid: $('#SystemcustomerId').val(), Firstname: $('#SystemcustomerfirstnameId').val(), Lastname: $('#SystemcustomerlastnameId').val(), Customeremail: $('#SystemcustomeremailaddressId').val(), Phoneid: $('#inputGroup-sizing-sm').val(), Phonenumber: $('#SystemcustomerphonenumberId').val(),
        Idnumber: $('#SystemcustomeridnumberId').val(), Licensenumber: $('#SystemcustomerlicensenumberId').val(), Krapin: $('#SystemcustomerkrapinnumberId').val(), Gender: $("input[type=radio][name=Gender]:checked").val(),
        Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(),Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/CustomerManagement/Addsystemcustomerdata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Customer details  Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}


function Savesystemrolesdetails() {
    var checkboxes = document.querySelectorAll('input[type="checkbox"]:checked');
    var Perms = new Array();
    checkboxes.forEach((checkbox) => {
        var Permission = {};
        Permission.PermissionId = checkbox.value;
        Perms.push(Permission);
    });
    var uil = { RoleId: $('#RoleIdValueId').val(), Rolename: $('#RolenameId').val(), Roledescription: $('#DescriptionId').val(), Permissions: Perms };
    $.post("/StaffManagement/Addsystemroledata", uil, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#FuelcardsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else {
            Swal("Role Detail Not Created", response.RespMessage, "error"); //$('.blockOverlay').hide();
        }
    });
}

function Savesystemstaffdetails() {
    var uil1 = {
        Tenantid: $('#systemLoggedinedtenantid').val(), StaffId: $('#SystemstaffId').val(), Displayname: $('#SystemshopnameId').val(), Firstname: $('#SystemstafffirstnameId').val(), Lastname: $('#SystemstafflastnameId').val(), Emailaddress: $('#SystemstaffemailaddressId').val(), Roleid: $('#SystemstaffroleId').val(),
        Phoneid: $('#inputGroup-sizing-sm').val(), Phonenumber: $('#SystemstaffphonenumberId').val(), Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(),
        Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/StaffManagement/Addsystemstaffdata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Shop and staff details  Not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}


function Getsystemrolebyid(event) {
    $.get("/StaffManagement/Getsystemrolebyid?RoleId="+event, function (response) {
        if (response && response.length > 0) {
            $("#DukawaremallsystemModal").show();
            $('input[type="checkbox"]').each(function () {
                var checkbox = $(this);
                var permissionId = checkbox.val();
                if (response.includes(permissionId)) {
                    checkbox.prop('checked', true);
                }
            });
        }
    });
}
function Savesystemcustomerloandetails() {
    var uil1 = {
        Customerid: $('#SystemcustomerId').val(), Assetid: $('#SystemcustomerassetidId').val(), Assetname: $('#SystemcustomerassetnameId').val(), Assetnumber: $('#SystemcustomerassetregistrationId').val(), Assetmakeid: $('#SystemcustomerassetmakeId').val(), Assetmodelid: $('#SystemcustomerassetmodelId').val(),
        Assetchasenumber: $('#SystemcustomerassetchaseId').val(), Yearofmanufacture: $('#SystemcustomerassetyearofmanufactureId').val(), Tankcapacity: $('#SystemcustomerassettankcapacityId').val(), Odometerreading: $('#SystemcustomerassetodometerreadingId').val(),
        Loanamount: $('#SystemcustomerloanprincipleamountId').val(), Paidamount: $('#SystemcustomerloanpaidamountId').val(), Interestrate: $('#SystemcustomerloaninterestrateId').val(), Loanperiod: $('#SystemcustomerloanperiodId').val(), Paymentterm: $('#SystemcustomerloanpaymenttermId').val(), Startdate: $('#SystemcustomerloanstartdateId').val(),
        Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(), Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/CustomerManagement/Addsystemcustomerloandata", uil1, function (response) {
        if (response.RespStatus == 0) {
            Swal.fire('Saved!', response.RespMessage, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Customer loan details not saved", response.RespMessage, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}


function showsystemloanassetfields(event) {
    var Assetname = event.target;
    $("#SystemcustomerassetidId").val(Assetname.getAttribute('data-Columnid'));
    if (Assetname.getAttribute('data-Columnidname') === "Cars") {
        $(".Systemassetcarfields").show();
        $(".Systemloandatafields").show();
    } else {
        $(".Systemassetcarfields").hide();
        $(".Systemloandatafields").hide();
    }
}

function getsystemvehiclemodels(vehiclemakeid) {
    var onj = "<option value=''>Select Make</option>";
    if (vehiclemakeid == "") { $('#SystemcustomerassetmodelId').html(onj); return; }
    $.get("/CustomerManagement/Getsystemdropdowndatabyid/" + vehiclemakeid, null, function (data) {
        $.each(data, function (a, x) { onj = onj + "<option value='" + x.Value + "'>" + x.Text + "</option>"; })
        $('#SystemcustomerassetmodelId').html(onj);
    });
}

function Savesystemcustomerpaymentdetails() {
    var uil1 = {
        TimeStamp: getTimestamp(), ServiceCode: $('#systemLoggedinedShortCodeId').val(), Assetnumber: $('#Systemcustomerassetnamerid').val(),
        LoanDetailId: $('#Loandetailid').val(), Loandetailitemid: $('#Loandetailitemid').val(), Phonenumber: $('#Systemcustomerphonenumberid').val(), Paymentamount: $('#SystemcustomerPaymentamountId').val(), Recievedamount: $('#SystemcustomerRecievedamountId').val(),
        AccountId: $('#Systemcustomeraccountid').val(), AccountNumber: $('#Systemcustomeraccountnumberid').val(), Paymentmemo: $('#SystemcustomermemoId').val(), Createdby: $('#systemLoggedinedUserid').val(), Modifiedby: $('#systemLoggedinedUserid').val(), Datecreated: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '), Datemodified: new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0].replace('T', ' '),
    };
    $.post("/CustomerManagement/Payloaninvoiceitemdata", uil1, function (response) {
        alert(JSON.stringify(response));
        if (response.status == 0 || response.Status == 0) {
            Swal.fire('Saved!', response.message, 'success')
            $('#DukawaremallsystemModal').hide();
            setTimeout(function () { location.reload(); }, 1000);
        } else if (response.RespStatus == 1) {
            Swal.fire("Details not saved", response.message, "warning");
        }
        else {
            Swal.fire("Oops! Something Went Wrong", "Database Error has occured. Kindly Contact our support team.", "error");
        }
    });
}

function getTimestamp() {
    const date = new Date();
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');

    return `${year}${month}${day}${hours}${minutes}${seconds}`;
}