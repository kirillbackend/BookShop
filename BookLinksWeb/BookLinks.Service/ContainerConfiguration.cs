using Autofac;
using BookLinks.Service.Services.Interface;
using BookLinks.Service.Services;
using FS.Services.Services.Contracts;
using FS.Services.Services;


namespace BookLinks.Service
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder, BookLinksSettings settings)
        {
            builder.RegisterInstance(settings);

            builder.RegisterType<IAccountService>().As<AccountService>();
            builder.RegisterType<IUserService>().As<UserService>();
            builder.RegisterType<IBookService>().As<BookService>();
            builder.RegisterType<ILinkService>().As<LinkService>();
            builder.RegisterType<IFileService>().As<FileService>();
            builder.RegisterType<IOrderService>().As<OrderService>();

            //Доделать по примеру
            //Repositories.ContainerConfiguration();
        }
    }
}
