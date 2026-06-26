using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bucther_app.DataAccess.Helpers
{
    public static class DbSettings
    {
        // В реальном проекте строку лучше хранить в App.config или в secrets.
        // Здесь для примера захардкодим, но вы можете заменить на чтение из конфига.
        public static string ConnectionString { get; set; } =
            "Server = HOMENET157\\SQLEXPRESS; Database=Butcher;Trusted_Connection=True;TrustServerCertificate=True";
    }
}
