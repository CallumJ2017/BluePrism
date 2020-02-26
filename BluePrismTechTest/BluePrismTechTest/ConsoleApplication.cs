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

		public void Run(string dictionaryFile, string startWord, string endWord, string outputFile, int length)
		{
			var dictionary = _dictionaryService.ReadTextFile(dictionaryFile);
			var dictionaryTwo = _dictionaryService.GetWordsOfLength(length, dictionary);
			_dictionaryService.Start(startWord, endWord, dictionaryTwo);
		}
	}
}
