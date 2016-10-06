using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SortFileData
{
	class SortFileDataSoln
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter File Name: ");
			String fileName = Console.ReadLine();
			//Checking if fileName is valid and fileContents are in expected format
			if (ValidateFileContents(fileName) && ReadFileContents(fileName) != null)
			{
				List<Student> studentInfo = ReadFileContents(fileName);
				// Sorting Student Data
				studentInfo.Sort();
				//Writing the contents to console for reference purpose
				foreach (Student s in studentInfo)
				{
					Console.WriteLine(s.getFirstName().ToString() + " - " + 
					                  s.getLastName().ToString() + " - " + s.getScore());
				}

				//Getting the input file's root directory
				String[] dir = fileName.Split(':');
				String[] trimExt = dir[1].Split('.');

				//Creating an output file in the input file's root directory
				StreamWriter file = new StreamWriter(dir[0] + ":\\" + trimExt[0] + "-graded.txt");
				//Writing student info line by line into output file
				foreach (Student s in studentInfo)
				{
					file.WriteLine(s.toString());
				}
				file.Close();
			}
			else
				Console.WriteLine("Problem occured while parsing the given file.");
		}

		/*
		 * Method to check if the file valid or not.
		 */
		public static Boolean ValidateFile(String fileName)
		{
			if (File.Exists(fileName))
			{
				Console.WriteLine("File is valid");
				//Checking if file extention is .txt or not
				String ext = Path.GetExtension(fileName);
				//Check if file extension is in proper format or not
				if (ext == ".txt")
				{
					Console.WriteLine("File Extension is valid");
					return true;
				}
				else
				{
					Console.WriteLine("Extension not in proper format. Please give file name with .txt extension");
					return false;
				}
			}
			else
			{
				Console.WriteLine("File Does Not Exist or User Does Not have Required Permissions to Open the File");
				return false;
			}
		}
		/*
		 * Method to check if the file contents are in expected format or not.
		 */
		public static List<Student> ReadFileContents(String fileName)
		{
			//Checking if the file Data is in write format or not
			String[] fileContent = File.ReadAllLines(fileName);
			List<Student> studentsList = new List<Student>();
			foreach (String s in fileContent)
			{
				if (Regex.IsMatch(s, "(\\w+,\\s\\w+,\\s\\d+)"))
				{
					String[] eachLine = s.Split(',');
					//Add Students information into the ArrayList
					studentsList.Add(new Student(eachLine[0], eachLine[1], Int32.Parse(eachLine[2])));
				}
				else
				{
					Console.WriteLine("Data is not in expected format. Please make sure that file data is in format " +
									  "LastName, FirstName, Score");
					return null;
				}
			}
			return studentsList;
		}
	}
}