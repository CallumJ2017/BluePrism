using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BluePrismTechTest
{
	class Program
	{
		private const int WordLength = 4;

		static int Main(string[] args)
		{
			// Set up varibales to hold the command line arguments.
			string dictionaryFile = "";
			string startWord = "";
			string endWord = "";
			string outputFile = "";

			// Do we have any command line arguments?
			if (args.Length == 0)
			{
				Console.WriteLine("No arguments submitted");
				Console.ReadLine();
				return 1;
			}

			// Lets read in the command line arguments and assign to variables.
			if (args.Length == 4)
			{
				for(int i = 0; i < args.Length; i++)
				{
					switch(i)
					{
						case 0:
							dictionaryFile = args[i];
							break;
						case 1:
							startWord = args[i];
							break;
						case 2:
							endWord = args[i];
							break;
						case 3:
							outputFile = args[i];
							break;
					}
				}
			}
			else
			{
				Console.WriteLine("Not enough command line arguments passed in.");
				Console.ReadLine();
				return 1;
			}

			// Create service collection and configure our services
			var services = ConfigureServices();

			// Generate a provider
			var serviceProvider = services.BuildServiceProvider();
			serviceProvider.GetService<ConsoleApplication>().Run(dictionaryFile, startWord, endWord, outputFile, WordLength);

			return 0;
		}

		private static IServiceCollection ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();

			// Set up the objects we need to get to configuration settings
			var config = LoadConfiguration();

			// Add the config to our DI container for later user
			services.AddSingleton(config);
			services.AddTransient<IDictionaryService, DictionaryService>();
			services.AddTransient<IFileHandler, FileHandler>();

			services.AddTransient<ConsoleApplication>();
			return services;
		}

		public static IConfiguration LoadConfiguration()
		{
			return new ConfigurationBuilder().Build();
		}
	}
}
