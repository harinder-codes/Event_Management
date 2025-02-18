using Event_Management.Repository.Admin;
using Event_Management.Repository.Login;
using Event_Management.Repository.Notification;
using Event_Management.Repository.User;
using Event_Management.Service;
using Event_Management.Service.Admin;
using Event_Management.Service.Login;
using Event_Management.Service.Notification;
using Event_Management.Service.User;
using System;

using Unity;

namespace Event_Management
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<INotificationService, NotificationService>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<INotificationRepository, NotificationRepository>();
        }
    }
}