using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BluePrismTechTest
{
	public class FileHandler : IFileHandler
	{
		public List<string> ReadTextFile(string dictionaryFile)
		{
			List<string> textFileList = new List<string>();

			// Read the whole text file.
			textFileList = File.ReadAllLines(dictionaryFile).ToList();

			// Sort the list alphabetically.
			textFileList.Sort();

			return textFileList;
		}
	}
}
