using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrismTechTest
{
	public interface IDictionaryService
	{
		void BuildTree(string word, Dictionary<string, List<string>> graph);
		void Start(string startWord, string endWord, Dictionary<string, List<string>> dictionary, List<string> textFile);
		List<string> ListOfOneCharcaterDifferentWords(string prevWord, List<string> dictionary);
		bool WordExistsInDictionary(string word, List<string> dictionary);
		Dictionary<string, List<string>> GetWordsOfLength(int number, List<string> dictionary);
	}
}
