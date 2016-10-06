using NUnit.Framework;
using System;
using SortFileData;
using System.IO;
using System.Collections.Generic;

namespace UnitTestSortFileData
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void FileValidation()
		{
			FileStream F = new FileStream("E:\\Input.txt", FileMode.Open, FileAccess.Read);
			Boolean b = SortFileDataSoln.ValidateFile(F.ToString());
			Assert.Equals(true, b);
		}

		public void DataValidation()
		{
			FileStream F = new FileStream("E:\\Input.txt", FileMode.Open, FileAccess.Read);
			List<Student> testList = SortFileDataSoln.ReadFileContents(F.ToString());
			Assert.NotNull(testList);
		}
	}
}
