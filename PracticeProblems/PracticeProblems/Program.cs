﻿// See https://aka.ms/new-console-template for more information
using PracticeProblems;

//var stringsProblems = new CtCIStringsProblems();
//var strs = new string[] { "dog", "racecar", "car" };
//var strs = new string[] { "flower", "flow", "flight" };
//var result = stringsProblems.HasUniqueCharacters("abade");
//var result = stringsProblems.IsPermutation("abcde", "adccb");
//var result = stringsProblems.IsPalindromePermutation("tacocat");
//var result = stringsProblems.IsOneAway("abce", "abce");
//var result = stringsProblems.CompressString("abcd");
//var result = stringsProblems.LongestCommonPrefix(strs);
//Console.WriteLine("Result:");
//Console.WriteLine(result.ToString());


//var intProblems = new IntProblems();
//var intInput = 1994;
//var intOutput = intProblems.IntToRoman(intInput);
//Console.WriteLine("IntOutput: " + intOutput);

//var arrayProblems = new ArrayProblems();
//var arrayInput = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
//var arrayInput = new int[] { -1, 0, 1, 2, -1, -4 };
//var arrayInput = new int[] { 0, 0, 0 };
//var arrayInput = new int[] { 0, 1, 1 };
//var arrayInput = new int[] { 1, 2, 3 };
//var arrayInput = new List<IList<int>> { new List<int> { 2 }, new List<int> { 3, 4 }, new List<int> { 6, 5, 7 }, new List<int> { 4, 1, 8, 3 } };
//var arrayInput = new List<IList<int>> { new List<int>{ -1 }, new List<int>{ -2, -3 }};
//var arrayInput = new List<IList<int>> { new List<int> { -1 }, new List<int> { 2, 3 }, new List<int> { 1, -1, -3 } };
//var arrayInput = new int[] { 1, -1, -1, 0 };
//var arrayInput = new int[] { 2, 3, 1, 1, 4 };
//var arrayInput = new int[] { 3, 2, 1, 0, 4 };
//var arrayInput = new List<char[]> { 
//    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' }, 
//    new char[] { '6','.','.','1','9','5','.','.','.' }, 
//    new char[] { '.','9','8','.','.','.','.','6','.' },
//    new char[] { '8','.','.','.','6','.','.','.','3' },
//    new char[] { '4','.','.','8','.','3','.','.','1' },
//    new char[] { '7','.','.','.','2','.','.','.','6' },
//    new char[] { '.','6','.','.','.','.','2','8','.' },
//    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
//    new char[] { '.','.','.','.','8','.','.','7','9' },
//}.ToArray();
//var arrayInput = new int[] { 1, 2, 5 };
//var arrayInput = new int[] { 2 };
//var arrayInput = new int[] { 1 };
//var arrayInput = new int[] { 186, 419, 83, 408 };
//var arrayInput = new int[] { -1, 2, 1, -4 };

//var arrayOutput = arrayProblems.Permute(arrayInput);
//var arrayOutput = arrayProblems.ThreeSumClosest(arrayInput, 1);
//Console.WriteLine("ArrayOutput: " + arrayOutput.ToString());

var grindInput = new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 } };
var grindProblems = new Grind75Week1();
var grindOutput = grindProblems.FloodFill(grindInput, 1, 1, 2);
Console.WriteLine();

/* Median of 2 sorted arrays */
//var leet = new LeetMedianOfTwoSortedArrays_4();
//var nums1 = new int[] { 1 };
//var nums2 = new int[] { 2, 3};

//var medianResult = leet.FindMedianSortedArrays(nums1, nums2);
/* Median of 2 sorted arrays */

//var leet = new LeetLongestPalindromeSubstring();
//var input = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
//var output = leet.LongestPalindrome(input);

//Console.WriteLine(output);