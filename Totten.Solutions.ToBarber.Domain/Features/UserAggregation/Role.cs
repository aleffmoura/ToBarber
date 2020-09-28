using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;

namespace Totten.Solutions.ToBarber.Domain.Features.UserAggregation
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public ERoleLevel Level { get; set; }
        public List<User> Users { get; set; }
    }
}
