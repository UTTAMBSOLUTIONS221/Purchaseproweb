namespace Purchaseproweb.Models
{
    public class UsermodelResponce
    {
        public int Respstatus { get; set; }
        public string? RespMessage { get; set; }
        public string? Token { get; set; }
        public UserModel? Usermodel { get; set; }
    }
}
