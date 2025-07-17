namespace RealEstate.Infrastructure.Commons
{
    public interface IAuditableEntity
    {
        DateTime CreateAt { get; set; }
        int? CreatedBy { get; set; }
        DateTime? LastModifiedAt { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? DeleteAt { get; set; }
        DateTime? DeletedBy { get; set; }
    }
}
