using CA.Core.Domain.Common;


namespace CA.Core.Application.DTOs
{
    public class ItemDTO : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}