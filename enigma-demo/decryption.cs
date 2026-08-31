namespace enigma_demo;

using static Common;
public static class Decryption
{
    public static string Decrypt(string cipherText, string key)
    {
        if (key.Length < cipherText.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        char[] result = new char[cipherText.Length];
        for (int current_index = 0; current_index < cipherText.Length; current_index++)
        {
            int new_index = character_to_index(cipherText[current_index]);
            int reduced = new_index - character_to_index(key[current_index]);
            if (reduced < 0)
            {
                reduced = 27 + reduced;
            }
            result[current_index] = index_to_character(reduced);
        }

        string result_string = new string(result);
        return result_string;
    }
}