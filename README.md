# Transmax
Sorting File Data Coding Challenge with unit tests

C# code for sorting file data based on scores.

Approach:
1) Created Student class with following instance vairables and respective getter methods
  - firstName - getFirstName()
  - lastName - getLastName()
  - score - getScore()
2) Overridden CompareTo() function to compare scores first and if scores are equal to compare lastNames
3) Overriden ToString() function to return string in expected format.
4) Written consumer class which does following
  - Accepts input(Input fileName) from the user
  - Checks the following
    - if the file is valid or not.
    - if the file extension is valid or not (.txt)
    - if the file contents are in expected format or not. (lastName, firstName, score)
  - Once file contents are read, Student object is formed and placed in List
  - Data in List is sorted and placed in output file. (Output file will be created in the root directory of the input file)
