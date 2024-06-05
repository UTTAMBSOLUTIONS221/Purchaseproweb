namespace Purchaseproweb.Models
{
    public class Systemreportdataandparameters
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public long customerid { get; set; }
        public long assetdetailid { get; set; }
        public long loanstatus { get; set; }
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public string? Customername { get; set; }
        public string? Assetdetailname { get; set; }
        public string? Loanstatusname { get; set; }
        public IEnumerable<Systemloanrepaymentmodel>? Loanrepaymentreportdata { get; set; }
}
}
