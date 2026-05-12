using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void SH_Key_gen_1()
        {
            Assert.IsTrue(Vernam.GenKey());
        }
        [TestMethod]
        public void SH_Code_message_1()
        {
            Assert.IsTrue(Vernam.Encode("QSQW", "abcd"));
            Assert.AreEqual(Vernam.Result, "0123");
        }
        [TestMethod]
        public void DESH_Decode_message_1()
        {
            Assert.IsTrue(Vernam.Decode("0123", "abcd"));
            Assert.AreEqual(Vernam.Result, "QSQW");
        }
        [TestMethod]
        public void SH_Key_Unique_1()
        {
            Vernam.GenKey();
            string key1 = Vernam.GeneratedKey;
            Vernam.GenKey();
            string key2 = Vernam.GeneratedKey;
            Assert.AreNotEqual(key1, key2);
        }
        [TestMethod]
        public void DESH_Decode_message_2()
        {
            Assert.IsTrue(Vernam.Decode("0123", "TEHO"));
            Assert.AreNotEqual(Vernam.Result, "QSQW");
        }
        [TestMethod]
        public void SH_code_short_key_1()
        {
            Assert.IsFalse(Vernam.Encode("I love XOR and security", "TEHO"));   
        }
        [TestMethod]
        public void DESH_Decode_short_key_1()
        {
            Assert.IsFalse(Vernam.Decode("I love XOR and security", "TEHO"));
        }
        [TestMethod]
        public void White_Space_1()
        {
            Assert.IsFalse(Vernam.Decode("  ", ""));
            Assert.IsFalse(Vernam.Encode("", "  "));
        }
    }
}
