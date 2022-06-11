using DDD.Domain;
using DDD.Application.ApplicationService;
using DDD.Domain.DomainService;
using DDD.Domain.Repositories;
using DDD.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Factories;
using DDD.Infrastructure.Fake;

namespace DDD.Practice
{
    class Program
    {
        private static ServiceProvider serviceProvider;

        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Startup();

            while (true)
            {
                Console.WriteLine("Input user name");
                Console.Write(">");
                var inputName = Console.ReadLine();
                Console.WriteLine("Input user mailaddress");
                Console.Write(">");
                var inputMailAddress = Console.ReadLine();
                var userApplicationService = serviceProvider.GetService<UserApplicationService>();
                var command = new UserRegisterCommand(inputName, inputMailAddress);
                userApplicationService.Register(command);

                Console.WriteLine("--------------------");
                Console.WriteLine("user created:");
                Console.WriteLine("--------------------");
                Console.WriteLine("user name:");
                Console.WriteLine("- " + inputName);
                Console.WriteLine("--------------------");

                Console.WriteLine("continue? (y/n)");
                Console.Write(">");
                var yesOrNo = Console.ReadLine();
                if(yesOrNo.ToLower() == "n")
                {
                    break;
                }
            }
        }

        private static void Startup()
        {
            // IoC Container
            var serviceCollection = new ServiceCollection();
            // 依存関係の登録を行う（以下コメントにて補足）
            // IUserFactoryが要求されたらInMemoryUserFactoryを生成して引き渡す（生成したインスタンスはその後使いまわされる）
            serviceCollection.AddSingleton<IUserFactory, InMemoryUserFactory>();
            // IUserRepositoryが要求されたらInMemoryUserRepositoryを生成して引き渡す（生成したインスタンスはその後使いまわされる）
            serviceCollection.AddSingleton<IUserRepository, InMemoryUserRepository>();
            // UserServiceが要求されたら都度UserServiceを生成して引き渡す
            serviceCollection.AddTransient<UserService>();
            // UserApplicationServiceが要求されたら都度UserApplicationServiceを生成して引き渡す
            serviceCollection.AddTransient<UserApplicationService>();
            // 依存解決を行うプロバイダの生成
            // プログラムはserviceProviderに依存の解決を依頼する
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
