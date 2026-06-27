using Bucther_app.Services.Implementations;
using Bucther_app.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Services
{
    public static class ServicesModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<INavigationService, NavigationService>(); // будет заменено позже
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IKitchenService, KitchenService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ITableService, TableService>();

            return services;
        }
    }
}
