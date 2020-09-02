using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Impl;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Validators;
using PetShop.Core.Validators.Impl;

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
            serviceCollection.AddScoped<IInputValidators, InputValidators>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            var inputValidators = serviceProvider.GetRequiredService<IInputValidators>();
            var ownerService = serviceProvider.GetRequiredService<IOwnerService>();

            var printer = new Printer(petService, inputValidators, ownerService);
            printer.ShowMenu();

            Console.ReadLine();
        }
    }
}
