using Domain.Common;

namespace Domain.MaintainEntity.Users
{
    public class User : LocalEntity<Guid>
    {
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
