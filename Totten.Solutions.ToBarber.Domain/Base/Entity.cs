using System;
using System.Collections.Generic;
using System.Text;

namespace Totten.Solutions.ToBarber.Domain.Base
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedIn { get; set; }
        public long Version { get; set; }
    }
}
