using System;
using System.Collections.Generic;
using System.Threading;

namespace Totten.Solutions.ToBarber.Tests.Commons
{
    public class CommonValues
    {
        public static CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        public static Guid UserCreatedId = Guid.NewGuid();

        public static Guid CompanyId = Guid.NewGuid();

        public static List<Guid> EmployeesID = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid()
        };

    }
}
