namespace basic_cryptography_demo_tests;
using basic_cryptography_demo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase('a', 0)]
    [TestCase('b', 1)]
    [TestCase('z', 25)]
    [TestCase(' ', 26)]
    public void TestCharToIndex(char c, int expected)
    {
        var result = Common.character_to_index(c);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, 'a')]
    [TestCase(1, 'b')]
    [TestCase(25, 'z')]
    [TestCase(26, ' ')]
    public void TestIndexToChar(int c, char expected)
    {
        var result = Common.index_to_character(c);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("helloworld", "abcdefgijkl", "hfnosauzun")]
    public void TestEncrypt(string plainText, string key, string expected)
    {
        var result = Encryption.Encrypt(plainText, key);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hfnosauzun", "abcdefgijkl", "helloworld")]
    public void TestDecrypt(string cipherText, string key, string expected)
    {
        var result = Decryption.Decrypt(cipherText, key);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hello world", "gcsohmrgmslohtsrgv")]
    [TestCase("something", "megszentsegtelenithetetlensegeskedeseitekert")]
    [TestCase("a quick brown fox jumps over the lazy dog",
        "abacabadabacabaeabacabadabacabafabacabadabacabaeabacabadabacaba")]
    public void TestBackAndForth(string plainText, string key)
    {
        var encrypted = Encryption.Encrypt(plainText, key);
        var decrypted = Decryption.Decrypt(encrypted, key);
        Assert.That(decrypted, Is.EqualTo(plainText));
    }

    [TestCase("abc", "ab")]
    [TestCase("Abc", "abc")]
    public void TestExceptionEncryption(string plainText, string key)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Encryption.Encrypt(plainText, key));
    }

    [TestCase("abc", "ab")]
    [TestCase("Abc", "abc")]
    public void TestExceptionDecryption(string plainText, string key)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Decryption.Decrypt(plainText, key));
    }
}