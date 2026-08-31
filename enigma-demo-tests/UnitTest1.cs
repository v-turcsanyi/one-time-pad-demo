namespace enigma_demo_tests;
using enigma_demo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("helloworld", "abcdefghijkl", "hfnosauzun")]
    public void TestEncrypt(string plainText, string key, string expected)
    {
        var result = Encryption.Encrypt(plainText, key);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hfnosauzun", "abcdefghijkl", "helloworld")]
    public void TestDecrypt(string cipherText, string key, string expected)
    {
        var result = Decryption.Decrypt(cipherText, key);
        Assert.That(result, Is.EqualTo(expected));
    }
}