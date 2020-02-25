using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrismTechTest
{
	public interface IDictionaryService
	{
		List<string> ReadTextFile(string dictionaryFile);
		void BuildTree(string startWord, string endWord, List<string> dictionary);
		void Start(string startWord, string endWord, List<string> dictionary);
		List<string> ListOfOneCharcaterDifferentWords(string prevWord, List<string> dictionary);
		bool WordExistsInDictionary(string word, List<string> dictionary);
		List<string> GetWordsOfLength(int number, List<string> dictionary);
	}
}
