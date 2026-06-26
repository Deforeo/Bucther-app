using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bucther_app.DataAccess.Helpers
{
    public static class SqlExceptionHelper
    {
        // Кастомные коды ошибок из ТЗ (50001-50008)
        public static void ThrowIfCustomError(SqlException ex)
        {
            // Если номер ошибки в диапазоне 50001-50008, выбрасываем исключение с сообщением от SQL.
            if (ex.Number >= 50001 && ex.Number <= 50008)
            {
                // Сообщение обычно содержится в ex.Message или в первом ошибке.
                throw new InvalidOperationException(ex.Message, ex);
            }
            // Иначе можно пробросить дальше как есть, либо обернуть в своё исключение.
        }

        // Вспомогательный метод для выполнения действий с перехватом
        public static T ExecuteWithErrorHandling<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (SqlException ex)
            {
                ThrowIfCustomError(ex);
                throw; // если не кастомная, пробрасываем дальше
            }
        }

        public static void ExecuteWithErrorHandling(Action action)
        {
            try
            {
                action();
            }
            catch (SqlException ex)
            {
                ThrowIfCustomError(ex);
                throw;
            }
        }
    }
}
