namespace AirTicketsService.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AirTicketsService.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AirTicketsService.Models.ApplicationDbContext";
        }

        protected override void Seed(AirTicketsService.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.AddOrUpdate(new IdentityRole()
            {
                Id = "Admin",
                Name = "Admin"
            });

            context.CityModels.AddOrUpdate(
                new CityModel() { Name = "Минск" },
                new CityModel() { Name = "Москва" },
                new CityModel() { Name = "Лондон" },
                new CityModel() { Name = "Стамбул" },
                new CityModel() { Name = "Санкт-Петербург" },
                new CityModel() { Name = "Берлин" },
                new CityModel() { Name = "Мадрид" },
                new CityModel() { Name = "Киев" },
                new CityModel() { Name = "Рим" },
                new CityModel() { Name = "Париж" },
                new CityModel() { Name = "Бухарест" },
                new CityModel() { Name = "Вена" },
                new CityModel() { Name = "Будапешт" },
                new CityModel() { Name = "Гамбург" },
                new CityModel() { Name = "Варшава" },
                new CityModel() { Name = "Барселона" },
                new CityModel() { Name = "Мюнхен" },
                new CityModel() { Name = "Харьков" },
                new CityModel() { Name = "Милан" },
                new CityModel() { Name = "Прага" },
                new CityModel() { Name = "София" },
                new CityModel() { Name = "Казань" },
                new CityModel() { Name = "Белград" },
                new CityModel() { Name = "Самара" },
                new CityModel() { Name = "Брюссель" },
                new CityModel() { Name = "Бирмингем" },
                new CityModel() { Name = "Одесса" },
                new CityModel() { Name = "Кельн" },
                new CityModel() { Name = "Неаполь" },
                new CityModel() { Name = "Турин" },
                new CityModel() { Name = "Марсель" },
                new CityModel() { Name = "Стокгольм" },
                new CityModel() { Name = "Саратов" },
                new CityModel() { Name = "Валенсия" },
                new CityModel() { Name = "Лидс" },
                new CityModel() { Name = "Амстердам" },
                new CityModel() { Name = "Краков" },
                new CityModel() { Name = "Лодзь" },
                new CityModel() { Name = "Львов" },
                new CityModel() { Name = "Севилья" },
                new CityModel() { Name = "Загреб" },
                new CityModel() { Name = "Франкфурт" },
                new CityModel() { Name = "Сарагоса" },
                new CityModel() { Name = "Кишинёв" },
                new CityModel() { Name = "Палермо" },
                new CityModel() { Name = "Афины" },
                new CityModel() { Name = "Рига" },
                new CityModel() { Name = "Вроцлав" },
                new CityModel() { Name = "Роттердам" },
                new CityModel() { Name = "Генуя" },
                new CityModel() { Name = "Штутгарт" },
                new CityModel() { Name = "Осло" },
                new CityModel() { Name = "Дюссельдорф" },
                new CityModel() { Name = "Хельсенки" },
                new CityModel() { Name = "Глазго" },
                new CityModel() { Name = "Дортмунд" },
                new CityModel() { Name = "Эссен" },
                new CityModel() { Name = "Малага" },
                new CityModel() { Name = "Оренбург" },
                new CityModel() { Name = "Гётеборг" },
                new CityModel() { Name = "Дублин" },
                new CityModel() { Name = "Познань" },
                new CityModel() { Name = "Бремен" },
                new CityModel() { Name = "Лиссабон" },
                new CityModel() { Name = "Вильнюс" },
                new CityModel() { Name = "Копенгаген" },
                new CityModel() { Name = "Тирана" },
                new CityModel() { Name = "Рязань" },
                new CityModel() { Name = "Брест" },
                new CityModel() { Name = "Гомель" },
                new CityModel() { Name = "Шеффилд" },
                new CityModel() { Name = "Астрахань" },
                new CityModel() { Name = "Пенза" },
                new CityModel() { Name = "Дрезден" },
                new CityModel() { Name = "Лейпциг" },
                new CityModel() { Name = "Ганновер" },
                new CityModel() { Name = "Лион" },
                new CityModel() { Name = "Киров" },
                new CityModel() { Name = "Казань" },
                new CityModel() { Name = "Порту" },
                new CityModel() { Name = "Ливерпуль" },
                new CityModel() { Name = "Манчестер" },
                new CityModel() { Name = "Астана" },
                new CityModel() { Name = "Сочи" },
                new CityModel() { Name = "Воронеж" },
                new CityModel() { Name = "Пермь" },
                new CityModel() { Name = "Ростов-на-Дону" }
                );
        }
    }
}
