namespace enigma_demo;

public static class Common
{
    public static string Characters = "abcdefghijklmnopqrstuvwxyz ";

    public static int character_to_index(char c)
    {
        var index = -1;
        if (c == ' ')
        {
            return 26;
        }
        else
        {
            index = c - 97; // in ASCII
        }

        if (index < 0 || index > 25)
        {
            throw new ArgumentOutOfRangeException();
        }

        return index;
    }

    public static char index_to_character(int c)
    {
        char result = '?';
        if (c > 26 || c < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (c == 26)
        {
            result = ' ';
        }
        else
        {
            result = Convert.ToChar(c + 97);
        }
        return result;
    }
}