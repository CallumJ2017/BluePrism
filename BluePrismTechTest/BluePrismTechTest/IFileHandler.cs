using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrismTechTest
{
	public interface IFileHandler
	{
		List<string> ReadTextFile(string dictionaryFile);
	}
}
