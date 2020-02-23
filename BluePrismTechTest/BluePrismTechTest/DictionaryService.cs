using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BluePrismTechTest
{
	public class DictionaryService : IDictionaryService
	{
		private readonly IConfiguration _configuration;
		private static List<List<string>> treeList = new List<List<string>>();
		private static Queue<string> visitedWords = new Queue<string>();
		private static List<string> textFileList = new List<string>();
		private int Levels = 0;

		public DictionaryService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ReadTextFile(string dictionaryFile)
		{
			// Read in only the words that are 4 characters in length.
			textFileList = File.ReadAllLines(dictionaryFile).Where(word => word.Length == 4).ToList();

			// Sort the list alphabetically.
			textFileList.Sort();
				
			foreach (var item in textFileList)
			{
				Console.WriteLine(item);
			}
		}

		public List<string> ListOfOneCharcaterDifferentWords(string prevWord)
		{
			List<string> tempList = new List<string>();

			foreach (var word in textFileList)
			{
				if (prevWord.Where((i, j) => word[j] != i).Count() == 1)
				{
					tempList.Add(word);
				}
			}
			return tempList;
		}

		public void Start(string startWord, string endWord)
		{
			if(!textFileList.Contains(endWord))
			{
				Console.WriteLine("The end word does not exist in the text file");
				Console.ReadKey();
				return;
			}

			BuildTree(startWord, endWord);
		}

		public void BuildTree(string startWord, string endWord)
		{
			while (true)
			{
				List<string> tempList = new List<string>();
				List<string> tempListTwo = new List<string>();

				tempList.Add(endWord);
				tempListTwo = ListOfOneCharcaterDifferentWords(endWord);

				foreach (var word in tempListTwo)
				{
					List<string> temp = new List<string>();
					temp.Add(endWord);
					temp.Add(word);
					treeList.Add(temp);
					visitedWords.Enqueue(word);
				}
				endWord = visitedWords.First();
				visitedWords.Dequeue().First();
			}
		}
	}
}
