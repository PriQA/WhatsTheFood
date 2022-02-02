namespace WhatsTheFoodService.Models
{
    public class AuthenticationReponse
    {
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }



    }
}
