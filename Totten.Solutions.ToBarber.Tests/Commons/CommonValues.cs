using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Tests.Commons
{
    public class CommonValues
    {
        public static CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        public static Guid UserCreatedId = Guid.NewGuid();
        public static Guid ClientId = Guid.NewGuid();
        public static Guid CompanyId = Guid.NewGuid();
        public static Guid EmployeeID = Guid.NewGuid();
        public static Guid UserEmployeeID = Guid.NewGuid();

        public static List<Guid> EmployeesID = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid()
        };


        #region ProvidedServices
        public static Guid ProvidedServicTanning = Guid.Parse("483f3ead-4eab-4931-9040-809d99eac3b7");
        public static Guid ProvidedServicNail = Guid.Parse("2f0f2371-5856-4156-b786-b26e0d95b85b");
        public static Guid ProvidedServicHairColoring = Guid.Parse("a23f13d5-0622-4026-b823-9a53e4a9f3ac");

        public static List<Guid> ProvidedServices = new List<Guid>
        {
            ProvidedServicTanning,
            ProvidedServicNail,
            ProvidedServicHairColoring
        };
        #endregion


        public static DateTime GetValidWeekDay()
        {
            DateTime date;

            do
            {
                date = DateTime.Now.AddDays(1);
            } while (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday);

            return date;
        }

        public static Task<Result<Exception, T>> ReturnTask<T>(T entity)
            => Task.Run(() => Result.Run(() => entity));
    }
}
