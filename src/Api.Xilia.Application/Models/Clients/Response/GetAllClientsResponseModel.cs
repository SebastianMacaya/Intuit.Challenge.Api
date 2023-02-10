using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Intuit.Application.Models.Clients.Response
{
    public class GetAllClientsResponseModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string cuit { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
