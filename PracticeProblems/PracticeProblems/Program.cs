// See https://aka.ms/new-console-template for more information
using PracticeProblems;

var stringsProblems = new CtCIStringsProblems();
//var result = stringsProblems.HasUniqueCharacters("abade");
//var result = stringsProblems.IsPermutation("abcde", "adccb");
//var result = stringsProblems.IsPalindromePermutation("tacocat");
//var result = stringsProblems.IsOneAway("abce", "abce");
var result = stringsProblems.CompressString("abcd");
Console.WriteLine(result.ToString());

/* Median of 2 sorted arrays */
//var leet = new LeetMedianOfTwoSortedArrays_4();
//var nums1 = new int[] { 1 };
//var nums2 = new int[] { 2, 3};

//var medianResult = leet.FindMedianSortedArrays(nums1, nums2);
/* Median of 2 sorted arrays */

var leet = new LeetLongestPalindromeSubstring();
var input = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
var output = leet.LongestPalindrome(input);

Console.WriteLine(output);