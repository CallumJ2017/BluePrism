using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluePrismTechTest
{
	public class DictionaryService : IDictionaryService
	{
		private static List<List<string>> treeList = new List<List<string>>();
		private static List<string> textFileList = new List<string>();

		public DictionaryService()
		{
		}

		public Dictionary<string, List<string>> GetWordsOfLength(int number, List<string> dictionary)
		{
			Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();
			
			// Get only the word of a certain length.
			foreach(var word in dictionary)
			{
				if(word.Length == 4)
				{
					temp.Add(word, dictionary);
				}
			}
			return temp;
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

		public void Start(string startWord, string endWord, Dictionary<string, List<string>> dictionary, List<string> textFile)
		{
			textFileList = textFile;

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

			var result = FindPaths(startWord, endWord, textFileList);

			foreach (var obj in result.FirstOrDefault())
			{
				Console.WriteLine(obj);
			}
			Console.ReadKey();
		}

		public List<List<string>> FindPaths(string startWord, string endWord, List<string> wordList)
		{
			var graph = new Dictionary<string, List<string>>();

			BuildTree(startWord, graph);

			foreach (var word in wordList)
			{
				BuildTree(word, graph);
			}

			//Queue For BFS
			var queue = new Queue<string>();

			//Dictionary to store shortest paths to a word
			var shortestPaths = new Dictionary<string, List<List<string>>>();

			queue.Enqueue(startWord);
			shortestPaths[startWord] = new List<List<string>>() { new List<string>() { startWord } };

			var visited = new List<string>();

			while (queue.Count > 0)
			{
				var visit = queue.Dequeue();

				//we can terminate loop once we reached the endWord as all paths leads here already visited in previous level 
				if (visit.Equals(endWord))
				{
					return shortestPaths[endWord];
				}

				if (visited.Contains(visit))
				{
					continue;
				}

				visited.Add(visit);

				for (int i = 0; i < visit.Length; i++)
				{
					var sb = new StringBuilder(visit);

					sb[i] = '*';

					var key = sb.ToString();

					if (!graph.ContainsKey(key))
					{
						continue;
					}

					//brute force all adjacent words
					foreach (var neighbor in graph[key])
					{
						if (visited.Contains(neighbor))
						{
							continue;
						}

						//fetch all paths leads current word to generate paths to adjacent/child node 
						foreach (var path in shortestPaths[visit])
						{
							var newPath = new List<string>(path);

							newPath.Add(neighbor); // path increments one, before it is saved in shortestPaths

							if (!shortestPaths.ContainsKey(neighbor))
							{
								shortestPaths[neighbor] = new List<List<string>>() { newPath };
							} 
							else if (shortestPaths[neighbor][0].Count >= newPath.Count)
							{
								shortestPaths[neighbor].Add(newPath);
							}
						}
						queue.Enqueue(neighbor);
					}
				}
			}
			return new List<List<string>>();
		}

		public bool WordExistsInDictionary(string word, List<string> dictionary)
		{
			return dictionary.Contains(word);
		}

		public void BuildTree(string word, Dictionary<string, List<string>> tree)
		{
			for (int i = 0; i < word.Length; i++)
			{
				var sb = new StringBuilder(word);
				sb[i] = '*';

				var key = sb.ToString();

				if (tree.ContainsKey(key))
				{
					tree[key].Add(word);
				}
				else
				{
					var set = new List<string>();
					set.Add(word);
					tree[key] = set;
				}
			}
		}
	}
}
