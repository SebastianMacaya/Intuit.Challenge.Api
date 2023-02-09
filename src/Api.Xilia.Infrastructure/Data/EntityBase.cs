using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Intuit.Infrastructure.Data
{
    public interface IDataModelBase { }

    public abstract class EntityBase : IDataModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //todas las entidades deben tener un Id de tipo Guid
        public Guid ID { get; set; }
    }

    public abstract class AuditEntityBase : EntityBase
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
