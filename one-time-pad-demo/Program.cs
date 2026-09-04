namespace one_time_pad_demo;

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
        Console.WriteLine("----------");
        const string key2 = "a quick brown fox jumped over the lazy dog";
        const string plaintext1 = "early bird catches the worm";
        var ciphertext1 = Encryption.Encrypt(plaintext1, key2);
        const string plaintext2 = "curiosity killed the cat";
        var ciphertext2 = Encryption.Encrypt(plaintext2, key2);
        const string known = "early";
        Console.WriteLine("Plain texts:");
        Console.WriteLine(plaintext1);
        Console.WriteLine(plaintext2);
        Console.WriteLine("Key:");
        Console.WriteLine(key2);
        Console.WriteLine("Known part:");
        Console.WriteLine(known);
        var keys = Attack.AttackSameKey([ciphertext1, ciphertext2], known);
        Console.WriteLine("Key candidates:");
        foreach (var candidate in keys)
        {
            /*try
            {*/
                Console.Write("- Key: ");
                Console.WriteLine(candidate);
                Console.Write("- Plain text 1: ");
                Console.WriteLine(Decryption.Decrypt(ciphertext1, candidate));
                Console.Write("- Plain text 2: ");
                Console.WriteLine(Decryption.Decrypt(ciphertext2, candidate));
                Console.WriteLine("--------------------");
            /*}catch (ArgumentOutOfRangeException)
            {
                
            }*/
        }
    }
}