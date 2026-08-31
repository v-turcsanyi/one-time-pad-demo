namespace enigma_demo;

using static Common;
public static class Encryption
{
    public static string Encrypt(string plainText, string key)
    {
        if (key.Length < plainText.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        var result = new char[plainText.Length];
        for (var currentIndex = 0; currentIndex < plainText.Length; currentIndex++)
        {
            var newIndex = character_to_index(plainText[currentIndex]);
            newIndex += character_to_index(key[currentIndex]);
            newIndex = newIndex % 27;
            result[currentIndex] = index_to_character(newIndex);
        }
        var resultString = new string(result);
        return resultString;
    }
}