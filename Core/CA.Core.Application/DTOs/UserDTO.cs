using CA.Core.Domain.Common;

namespace CA.Core.Application.DTOs
{
    public class UserDTO : AuditableEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}