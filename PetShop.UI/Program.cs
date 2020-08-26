using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Impl;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            var printer = new Printer(petService);
            Console.WriteLine("Welcome! \nHere is a list of the pets!");
            printer.GetPets();

            Console.ReadLine();
        }
    }
}
