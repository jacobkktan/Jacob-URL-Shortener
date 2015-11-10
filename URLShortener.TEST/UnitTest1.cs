using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using URLShortener.BL;

namespace URLShortener.TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GenerateCode()
        {
            var val = ShortGeneratorHelper.GenerateCode(5);
            if (string.IsNullOrEmpty(val)) { }
        }

        [TestMethod]
        public void CallHelper()
        {
            var Helper = new URLShortener.BL.Helper(@"D:\Projects\URLShorternerREST\DB\shortener.db");
            Helper.InsertRecord("https://tradingpost.my");
        }

        [TestMethod]
        public void GetUrl()
        {
            var Helper = new URLShortener.BL.Helper(@"D:\Projects\URLShorternerREST\DB\shortener.db");
            var url = Helper.GetUrl("MMMM");
        }

        [TestMethod]
        public void DeleteUrl()
        {
            var Helper = new URLShortener.BL.Helper(@"D:\Projects\URLShorternerREST\DB\shortener.db");
            Helper.DeleteUrl("MMMM");
        }
    }
}
