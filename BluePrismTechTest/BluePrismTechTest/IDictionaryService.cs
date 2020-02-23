using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrismTechTest
{
	public interface IDictionaryService
	{
		void ReadTextFile(string dictionaryFile);
		void BuildTree(string startWord, string endWord);
		void Start(string startWord, string endWord);
		List<string> ListOfOneCharcaterDifferentWords(string prevWord);
	}
}
