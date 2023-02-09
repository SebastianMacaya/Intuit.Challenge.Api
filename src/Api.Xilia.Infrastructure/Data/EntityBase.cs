namespace Api.Intuit.Infrastructure.Data
{
    public interface IDataModelBase { }

    public abstract class EntityBase : IDataModelBase
    {

    }

    public abstract class AuditEntityBase : EntityBase
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
