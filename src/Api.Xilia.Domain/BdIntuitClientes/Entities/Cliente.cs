using Api.Intuit.Infrastructure.Data;

namespace Api.Intuit.Domain.BdIntuitClientes.Entities
{
    public class Cliente : EntityBase
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string cuit { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
#pragma warning disable IDE1006 // Estilos de nombres
        public string email { get; set; }
#pragma warning restore IDE1006 // Estilos de nombres
        
    }
}
