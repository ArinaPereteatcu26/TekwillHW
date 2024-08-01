using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringValidatorLibrary;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class ListManipulatorTests
    {
        [TestMethod]
        public void FindMax_ListOfIntegers_ReturnsMaxValue()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int result = ListManipulator.FindMax(numbers);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void RemoveDuplicates_ListWithDuplicates_ReturnsListWithoutDuplicates()
        {
            List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            List<int> result = ListManipulator.RemoveDuplicates(numbers);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, result);
        }

        [TestMethod]
        public void RemoveDuplicates_EmptyList_ReturnsEmptyList()
        {
            List<int> numbers = new List<int>();
            List<int> result = ListManipulator.RemoveDuplicates(numbers);
            CollectionAssert.AreEqual(new List<int>(), result);
        }
    }
}
