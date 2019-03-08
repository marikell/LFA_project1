using System;
using LFA_Project1;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using LFA_Project1.Model;

namespace LFA_project1.Tests
{

    public class DerivatorTest
    {
        [Theory()]
        [InlineData(new string[] { "S", "X", "X", "X", "Aa", "Ab", "AY", "Ba", "Bb", "BY", "Fa", "Fb", "FY" },
        new string[] { "XY", "XaA", "XbB", "F", "aA", "bA", "Ya", "aB", "bB", "Yb", "aF", "bF", "" },
        "S",
        new int[] { 1, 2, 7, 3, 8, 10, 4, 12, 11, 13 },
        new string[] { "a", "b" },
        "baba")]
        // [InlineData(new string[] { "S", "Y", "XY", "Z" },
        // new string[] { "XYZ", "Yab", "", "cXY" },
        // "S",
        // new int[] { 1, 2, 3, 4, 3 },
        // new string[] { "a", "b", "c" },
        // "abc")]
        public void Derive(string[] ba, string[] aa, string InitialWord, int[] steps, string[] variables, string expectedResult)
        {
            Derivator derivator = new Derivator(new Derivation(ba, aa, steps, variables, InitialWord));
            Assert.Equal(expectedResult, derivator.Derive());

            var generatedSteps = derivator.GetStepsByWord(expectedResult).ToArray();

            Derivator derivator2 = new Derivator(new Derivation(ba, aa, generatedSteps, variables, InitialWord));
            Assert.Equal(expectedResult, derivator2.Derive());
        }

        [Theory()]
        [InlineData(new string[] { "S", "X", "X", "X", "Aa", "Ab", "AY", "Ba", "Bb", "BY", "Fa", "Fb", "FY" },
        new string[] { "XY", "XaA", "XbB", "F", "aA", "bA", "Ya", "aB", "bB", "Yb", "aF", "bF", "" },
        "S",
        new string[] { "a", "b" },
        "abab")]
        [InlineData(new string[] { "S", "X", "X", "X", "Aa", "Ab", "AY", "Ba", "Bb", "BY", "Fa", "Fb", "FY" },
        new string[] { "XY", "XaA", "XbB", "F", "aA", "bA", "Ya", "aB", "bB", "Yb", "aF", "bF", "" },
        "S",
        new string[] { "a", "b" },
        "bababa")]
        public void Derive2(string[] ba, string[] aa, string InitialWord, string[] variables, string expectedResult)
        {
            Derivator derivator = new Derivator(new Derivation(ba, aa, null, variables, InitialWord));
            var generatedSteps = derivator.GetStepsByWord(expectedResult).ToArray();

            Derivator derivator2 = new Derivator(new Derivation(ba, aa, generatedSteps, variables, InitialWord));
            Assert.Equal(expectedResult, derivator2.Derive());
        }

        [Theory()]
        [InlineData("aa", "ff", "AaaBbaa", "AffBbaa")]
        [InlineData("XY", "FUU", "KaXYAaL", "KaFUUAaL")]
        public void Replace(string wba, string waa, string word, string expectedResult)
        {
            Assert.Equal(expectedResult, Derivator.Replace(wba, waa, word));
        }

        [Theory()]
        [InlineData("", "ZZZ", "tttt")]
        public void ReplaceWithIndex(string wba, string waa, string word)
        {
            Assert.Equal("ZZZtttt", Derivator.Replace(wba, waa, word, 0));
            Assert.Equal("tZZZttt", Derivator.Replace(wba, waa, word, 1));
            Assert.Equal("ttZZZtt", Derivator.Replace(wba, waa, word, 2));
            Assert.Equal("tttZZZt", Derivator.Replace(wba, waa, word, 3));
            Assert.Equal("ttttZZZ", Derivator.Replace(wba, waa, word, 4));
        }


    }
}