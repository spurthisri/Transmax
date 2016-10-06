using System;
namespace SortFileData
{
	/*
	 * Student class which defines firstName, lastName and score
	 * with related getter methods.
	 */
	public class Student : IComparable<Student>
	{
		private String firstName;
		private String lastName;
		private int score;
		public Student(String firstName, String lastName, int score)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.score = score;
		}

		public String getFirstName()
		{
			return firstName;
		}

		public String getLastName()
		{
			return lastName;
		}

		public int getScore()
		{
			return score;
		}
		/*
		 * Overriding CompareTo method to compare score and if
		 * scores are equal compare firstNames
		 */
		public int CompareTo(Student s)
		{
			if (s == null)
				return 1;
			if (this.score == s.score)
				return firstName.CompareTo(s.firstName);
			return s.score.CompareTo(this.score);
		}

		/*
		 * Overriding toString method to give formatted output
		 */ 

		public string toString()
		{
			return this.getFirstName() + ", " + this.getLastName() + ", " + this.getScore();
		}
	}
}
