using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluePrismTechTest;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BluePrismTechTest.Tests
{
	[TestClass]
	public class DictionaryServiceTests
	{
		private List<string> dictionary;
		private readonly DictionaryService cut = new DictionaryService();

		[TestInitialize]
		public void TestSetUp()
		{
			dictionary = new List<string>();
			dictionary.Add("first");
			dictionary.Add("house");
			dictionary.Add("second");
			dictionary.Add("baby");
			dictionary.Add("car");
			dictionary.Add("apple");
			dictionary.Add("babe");
		}

		[TestMethod]
		public void Returns_False_When_Word_Not_In_Dictionary()
		{
			var result = cut.WordExistsInDictionary("pear", dictionary);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Returns_True_When_Word_Exists_In_Dictionary()
		{
			var result = cut.WordExistsInDictionary("baby", dictionary);

			Assert.IsTrue(result);
		}

		//[TestMethod]
		//[Ignore]
		//public void Reads_Only_FourCharacter_Words()
		//{
		//	// Arrange
		//	List<string> actual = cut.GetWordsOfLength(4, dictionary);

		//	int expected = 2;

		//	// Assert
		//	Assert.AreEqual(expected, actual.Count(), "Not all words read in are 4 characters");
		//	Assert.IsTrue(actual.Contains("baby"));
		//	Assert.IsTrue(actual.Contains("babe"));
		//}

		[TestMethod]
		[Ignore]
		public void Shortest_Path_Achieved()
		{
			// Arrange

			// Act

			// Assert
		}
	}
}
