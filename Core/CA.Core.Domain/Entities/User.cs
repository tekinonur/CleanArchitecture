using CA.Core.Domain.Common;

namespace CA.Core.Domain.Entities
{
    public class User : AuditableEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}