using Bucther_app.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess
{
    public static class DataAccessModule
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<DatabaseContext>(provider =>
                new DatabaseContext(Helpers.DbSettings.ConnectionString));

            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();

            return services;
        }
    }
}
