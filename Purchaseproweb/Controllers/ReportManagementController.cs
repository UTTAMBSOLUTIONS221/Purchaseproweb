using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Purchaseproweb.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Purchaseproweb.Enum;
using Purchaseproweb.Models;

namespace Purchaseproweb.Controllers
{
    [Authorize]
    public class ReportManagementController : BaseController
    {
        private readonly Wemanageservices bl;
        public ReportManagementController(IConfiguration config)
        {
            bl = new Wemanageservices(config);
        }

        public IActionResult Generatecustomerloanpayment()
        {
            ViewData["Systemcustomerslists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Systemcustomers).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            ViewData["Systemassetdetailslists"] = bl.GetSystemDropDownData(SessionUserData.Token, ListModelType.Systemassetdetails).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            return View();
        }
        public async Task<IActionResult> Generatecustomerloanpaymentpartialview(DateTime startdate, DateTime enddate,long customerid =0,long assetdetailid =0,  long loanstatus= -1)
        {

            var data = await bl.Generatecustomerloanpaymentdata(SessionUserData.Token, SessionUserData.Usermodel.Tenantid, startdate, enddate, customerid, assetdetailid, loanstatus);
            Systemreportdataandparameters model = new Systemreportdataandparameters
            {
                startdate = startdate,
                enddate = enddate,
                customerid = customerid,
                assetdetailid = assetdetailid,
                loanstatus = loanstatus,
                Customername = data.Customername,
				Assetdetailname = data.Assetdetailname,	
				Loanstatusname = data.Loanstatusname,
				Loanrepaymentreportdata = data.Loanrepaymentreportdata,
            };
            return PartialView(model);
    }
		public async Task<FileResult> GeneratePdf(DateTime startdate, DateTime enddate, long customerid = 0, long assetdetailid = 0, long loanstatus = -1)
		{
			MemoryStream workStream = new MemoryStream();
			StringBuilder status = new StringBuilder("");
			DateTime dTime = DateTime.Now;
			string strPDFFileName = string.Format("CustomersLoanDetailPdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
			Document doc = new Document();
			doc.SetMargins(0, 0, 0, 0);
			PdfPTable tableLayout = new PdfPTable(11);
			doc.SetMargins(10, 10, 10, 0);
			PdfWriter.GetInstance(doc, workStream).CloseStream = false;
			doc.Open();
			BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font fontInvoice = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
			Paragraph paragraph = new Paragraph("Loan Repayment Details", fontInvoice);
			paragraph.Alignment = Element.ALIGN_CENTER;
			doc.Add(paragraph);
			//design the filter headers
            Paragraph filterHeaders = new Paragraph("Loan Repayment Details", fontInvoice);
            paragraph.Alignment = Element.ALIGN_LEFT;
            doc.Add(filterHeaders);

            Paragraph p3 = new Paragraph();
			p3.SpacingAfter = 6;
			doc.Add(p3);
			doc.Add(await Add_Content_To_PDF(tableLayout, startdate, enddate, customerid, assetdetailid, loanstatus));
			doc.Close();
			byte[] byteInfo = workStream.ToArray();
			workStream.Write(byteInfo, 0, byteInfo.Length);
			workStream.Position = 0;
			return File(workStream, "application/pdf", strPDFFileName);
		}

		protected async Task<PdfPTable> Add_Content_To_PDF(PdfPTable tableLayout, DateTime startdate, DateTime enddate, long customerid = 0, long assetdetailid = 0, long loanstatus = -1)
		{
			float[] headers = { 14, 20, 24, 29,22, 27, 18, 23, 23, 24,28 }; //Header Widths  
			tableLayout.SetWidths(headers); //Set the pdf headers  
			tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
			tableLayout.HeaderRows = 1;
			var count = 1;

			//Add header  
			AddCellToHeader(tableLayout, "S/No.");
			AddCellToHeader(tableLayout, "Car Regno.");
			AddCellToHeader(tableLayout, "Car Make & Model");
			AddCellToHeader(tableLayout, "Driver's Name");
			AddCellToHeader(tableLayout, "Phone");
			AddCellToHeader(tableLayout, "Amt. Paid (KES)");
			AddCellToHeader(tableLayout, "Week No.");
			AddCellToHeader(tableLayout, "Status");
			AddCellToHeader(tableLayout, "Remarks");
			AddCellToHeader(tableLayout, "Current Week's Bal.");
			AddCellToHeader(tableLayout, "Cumulative Amt. Outstanding");

            var data = await bl.Generatecustomerloanpaymentdata(SessionUserData.Token, SessionUserData.Usermodel.Tenantid, startdate, enddate, customerid, assetdetailid, loanstatus);
            foreach (var cust in data.Loanrepaymentreportdata)
			{
				if (count >= 1)
				{
					AddCellToBody(tableLayout,count.ToString(), count);
					AddCellToBody(tableLayout, cust.AssetNumber, count);
					AddCellToBody(tableLayout, cust.AssetName, count);
					AddCellToBody(tableLayout, cust.CustomerName, count);
					AddCellToBody(tableLayout, cust.PhoneNumber, count);
					AddCellToBody(tableLayout, cust.PaidAmount.ToString("#,##0.00"), count);
					AddCellToBody(tableLayout, cust.Period.ToString(), count);
					AddCellToBody(tableLayout, cust.PaymentStatus, count);
					AddCellToBody(tableLayout, cust.PaymentReason, count);
					AddCellToBody(tableLayout, cust.WeeklyOutstandingBalance.ToString("#,##0.00"), count);
					AddCellToBody(tableLayout, cust.CumulativeOutstandingBalance.ToString("#,##0.00"), count);
					count++;
				}
			}
			return tableLayout;
		}

		private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
		{
			tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.TIMES_ROMAN, 6, 1, BaseColor.Black)))
			{
				HorizontalAlignment = Element.ALIGN_LEFT,
				Padding = 5,
				BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
			});
		}

		private static void AddCellToBody(PdfPTable tableLayout, string cellText, int count)
		{
			if (count % 2 == 0)
			{
				tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.TIMES_ROMAN, 5, 1, iTextSharp.text.BaseColor.Black)))
				{
					HorizontalAlignment = Element.ALIGN_LEFT,
					Padding = 5,
					BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
				});
			}
			else
			{
				tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 5, 1, iTextSharp.text.BaseColor.Black)))
				{
					HorizontalAlignment = Element.ALIGN_LEFT,
					Padding = 5,
					BackgroundColor = new iTextSharp.text.BaseColor(211, 211, 211)
				});
			}
		}
	}
}
