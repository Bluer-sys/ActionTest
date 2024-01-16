// See https://aka.ms/new-console-template for more information

using CsvParser;
using CsvParser.GoogleSheet;
using CsvParser.GoogleSheet.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<Application>();

//setup console logging
serviceCollection.AddLogging(s => s
	.AddConsole()
	.SetMinimumLevel(LogLevel.Debug));

//setup google sheets
serviceCollection
	.AddSingleton<IGoogleCredentialsProvider, GoogleCredentialsProvider>()
	.AddSingleton<IGoogleSheetsReader, GoogleSheetsReader>();

var serviceProvider = serviceCollection.BuildServiceProvider();
            
// run app
var application = serviceProvider.GetService<Application>();

await application!.RunAsync();