namespace basic_cryptography_demo;

using static Common;
public static class Decryption
{
    public static string Decrypt(string cipherText, string key)
    {
        if (key.Length < cipherText.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        var result = new char[cipherText.Length];
        for (var currentIndex = 0; currentIndex < cipherText.Length; currentIndex++)
        {
            var newIndex = character_to_index(cipherText[currentIndex]);
            var reduced = newIndex - character_to_index(key[currentIndex]);
            if (reduced < 0)
            {
                reduced = 27 + reduced;
            }
            result[currentIndex] = index_to_character(reduced);
        }

        var resultString = new string(result);
        return resultString;
    }
}