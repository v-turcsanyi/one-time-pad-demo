namespace enigma_demo;

class Program
{
    static void Main(string[] args)
    {
        const string plaintext = "helloworld";
        const string key = "abcdefgijkl";
        var ciphertext = Encryption.Encrypt(plaintext, key);
        Console.Write("Plain text: ");
        Console.WriteLine(plaintext);
        Console.Write("Key: ");
        Console.WriteLine(key);
        Console.Write("Ciphertext: ");
        Console.WriteLine(ciphertext);
        Console.WriteLine("----------");
        var decrypted = Decryption.Decrypt(ciphertext, key);
        Console.Write("Decrypted: ");
        Console.WriteLine(decrypted);
    }
}