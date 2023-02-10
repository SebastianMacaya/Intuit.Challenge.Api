namespace Api.Intuit.Application.Models.Clients.Request
{
    public class PostClientRequestModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string cuit { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
