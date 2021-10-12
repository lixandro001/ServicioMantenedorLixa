using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
   public static class DateTimeHelper
    {
        private static readonly DateTime DateTimeUnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static TimeSpan Tz = new TimeSpan(-3, 0, 0);

        public static DateTimeOffset Now => DateTimeOffset.UtcNow.ToOffset(Tz);

        public static long GetUnixTimeMilliseconds(DateTime value)
        {
            return (long)(value - DateTimeUnixEpoch).TotalMilliseconds;
        }

        public static string ReadableString(DateTimeOffset value)
        {
            return value.ToOffset(Tz).ToString("dd/MM/yyyy HH:mm");
        }

        public static (string, string) GetLast7Days()
        {
            DateTime fechaInicial = DateTime.Today;
            DateTime fechaFinal = fechaInicial.AddDays(-7);

            return (fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));
        }

    }
}
