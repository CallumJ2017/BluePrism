using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrismTechTest
{
	public class ConsoleApplication
	{
		private readonly IDictionaryService _dictionaryService;
		private readonly IFileHandler _fileHandler;

		public ConsoleApplication(IDictionaryService dictionaryService, IFileHandler fileHandler)
		{
			_dictionaryService = dictionaryService;
			_fileHandler = fileHandler;
		}

		public void Run(string dictionaryFile, string startWord, string endWord, string outputFile, int length)
		{
			var dictionary = _fileHandler.ReadTextFile(dictionaryFile);
			var tree = _dictionaryService.GetWordsOfLength(length, dictionary);
			_dictionaryService.Start(startWord, endWord, tree, dictionary);
		}
	}
}
