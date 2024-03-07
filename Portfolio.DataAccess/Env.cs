using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess
{
    internal static class Env
    {
        // Identity User
        public static string IU_ADMIN_ID = Environment.GetEnvironmentVariable("IU_ADMIN_ID");
        public static string IU_ADMIN_EMAIL = Environment.GetEnvironmentVariable("IU_ADMIN_EMAIL");
        public static string IU_ADMIN_USERNAME = Environment.GetEnvironmentVariable("IU_ADMIN_USERNAME");
        public static string IU_ADMIN_PASSWORD = Environment.GetEnvironmentVariable("IU_ADMIN_PASSWORD");
        public static string IU_ADMIN_CONCURRENCY_STAMP = Environment.GetEnvironmentVariable("IU_ADMIN_CONCURRENCY_STAMP");
    }
}