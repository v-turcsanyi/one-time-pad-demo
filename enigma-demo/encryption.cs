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
        char[] result = new char[plainText.Length];
        for (int current_index = 0; current_index < plainText.Length; current_index++)
        {
            int new_index = character_to_index(plainText[current_index]);
            new_index += character_to_index(key[current_index]);
            new_index = new_index % 27;
            result[current_index] = index_to_character(new_index);
        }
        string result_string = new string(result);
        return result_string;
    }
}