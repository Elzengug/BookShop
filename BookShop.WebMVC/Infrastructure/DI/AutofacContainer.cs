using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BookShop.Core.Models;
using BookShop.Data.Contexts;
using BookShop.Data.Repositories;
using BookShop.Data.Repositories.Implementations;
using BookShop.Data.Repositories.Interfaces;
using BookShop.Services.Interfaces;
using BookShop.Services.Services;

namespace BookShop.WebMVC.Infrastructure.DI
{
    public class AutofacContainer
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<BookService>().As<IBookService>().InstancePerRequest();
            builder.RegisterType<BasketService>().As<IBasketService>().InstancePerRequest();
            builder.RegisterType<BookOrderService>().As<IBookOrderService>().InstancePerRequest();
            builder.RegisterType<BookShopDbContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerRequest();
            builder.RegisterType<BookOrderRepository>().As<IBookOrderRepository>().InstancePerRequest();
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerRequest();
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}