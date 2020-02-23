using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrismTechTest
{
	public class ConsoleApplication
	{
		private readonly IDictionaryService _dictionaryService;

		public ConsoleApplication(IDictionaryService dictionaryService)
		{
			_dictionaryService = dictionaryService;
		}

		// Application starting point
		public void Run(string dictionaryFile, string startWord, string endWord, string outputFile)
		{
			_dictionaryService.ReadTextFile(dictionaryFile);
			_dictionaryService.Start(startWord, endWord);
		}
	}
}
