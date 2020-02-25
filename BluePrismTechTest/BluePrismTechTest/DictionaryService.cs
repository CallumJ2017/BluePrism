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

		public DictionaryService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public DictionaryService()
		{
		}

		public List<string> ReadTextFile(string dictionaryFile)
		{
			// Read the whole text file.
			textFileList = File.ReadAllLines(dictionaryFile).ToList();

			// Sort the list alphabetically.
			textFileList.Sort();

			return textFileList;
		}
		public List<string> GetWordsOfLength(int number, List<string> dictionary)
		{
			// Get only the word of a certain length.
			return dictionary.Where(word => word.Length == number).ToList();
		}

		public List<string> ListOfOneCharcaterDifferentWords(string prevWord, List<string> dictionary)
		{
			List<string> tempList = new List<string>();

			foreach (var word in dictionary)
			{
				// Check if the prev word and word differ by one character.
				// If so add them to the list.
				if (prevWord.Where((i, j) => word[j] != i).Count() == 1)
				{
					tempList.Add(word);
				}
			}
			return tempList;
		}

		public void Start(string startWord, string endWord, List<string> dictionary)
		{
			if (!WordExistsInDictionary(startWord, textFileList))
			{
				Console.WriteLine("Sorry, start word not found in dictionary.");
				Console.ReadKey();
				return;
			}
			if (!WordExistsInDictionary(endWord, textFileList))
			{
				Console.WriteLine("Sorry, end word not found in dictionary.");
				Console.ReadKey();
				return;
			}
			BuildTree(startWord, endWord, dictionary);
		}

		public bool WordExistsInDictionary(string word, List<string> dictionary)
		{
			return dictionary.Contains(word);
		}

		public void BuildTree(string startWord, string endWord, List<string> dictionary)
		{
			while (true)
			{
				List<string> tempList = new List<string>();
				List<string> tempListTwo = new List<string>();

				tempList.Add(endWord);
				tempListTwo = ListOfOneCharcaterDifferentWords(endWord, dictionary);

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
