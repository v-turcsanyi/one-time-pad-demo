namespace one_time_pad_demo;

public static class Attack
{
    /*private static void PrefixDepth(int depth)
    {
        for (int i = 0; i < depth + 1; i++)
        {
            Console.Write(i);
            Console.Write(" ");
        }
    }*/

    private static string[] AttackSubString(string[] messagesKnown, string[] messagesOriginal, string key, int depth)
    {
        var candidates = new List<string>();
        foreach (var item in messagesKnown)
        {
            // PrefixDepth(depth);
            // Console.WriteLine(item);
        }
        // PrefixDepth(depth);
        // Console.WriteLine("---");
        // PrefixDepth(depth);
        // Console.WriteLine(key);

        var keyKnown = new List<char>();
        int index = 0;
        foreach (var c in key.ToCharArray())
        {
            keyKnown.Add(c);
            index++;
        }

        for (int i = index; i < messagesKnown[0].Length; i++)
        {
            var newCharIndex = Common.character_to_index(messagesKnown[0].ToCharArray()[index]);
            var keyCharIndex = Common.character_to_index(messagesOriginal[0].ToCharArray()[index]);
            newCharIndex = keyCharIndex - newCharIndex;
            if (newCharIndex < 0)
            {
                newCharIndex += 27;
            }
            var newChar = Common.index_to_character(newCharIndex);
            keyKnown.Add(newChar);
            index++;
        }
        if(messagesKnown[0].Length == messagesOriginal[0].Length && messagesKnown[1].Length == messagesOriginal[1].Length)
        {
            candidates.Add(string.Concat(keyKnown));
            return candidates.ToArray();
        }

        // PrefixDepth(depth);
        // Console.WriteLine("---");
        // PrefixDepth(depth);
        // foreach (var item in keyKnown)
        // {
            // Console.Write(item);
        // }
        // Console.WriteLine();

        var keyKnownRender = new List<char>();
        foreach (var c in keyKnown)
        {
            keyKnownRender.Add(c);
        }
        for (int i = 0; i < messagesOriginal[0].Length + messagesOriginal[0].Length; i++)
        {
            keyKnownRender.Add('a'); // pad the reconstructed key for rendering
        }
        // PrefixDepth(depth);
        // Console.WriteLine("---");
        var keyKnownStr = string.Concat(keyKnownRender.ToArray());
        var messagesDecrypted = new string[messagesOriginal.Length];
        for (var i = 0; i < messagesOriginal.Length; i++)
        {
            var item = messagesOriginal[i];
            messagesDecrypted[i] = Decryption.Decrypt(item, keyKnownStr);
            // PrefixDepth(depth);
            // Console.WriteLine(messagesDecrypted[i]);
        }
        
        // PrefixDepth(depth);
        // Console.WriteLine("---");

        var candidatesWord2 = new List<string>();
        foreach (var word in WordDictionary.Words)
        {
            var offset = 0;
            if (key.Length == 0)
            {
                offset = 0;
            }
            var found = false;
            if (word.Length >= index - key.Length - offset)
            {
                for (var i = 0; i < index - key.Length - offset; i++)
                {
                    if (word[i] == messagesDecrypted[1][i + key.Length + offset])
                    {
                        if (i == index - key.Length - offset - 1)
                        {
                            found = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (found)
            {
                // PrefixDepth(depth);
                // Console.WriteLine(word);
                candidatesWord2.Add(word);
            }
        }
        foreach (var candidate in candidatesWord2)
        {
            try
            {
                // PrefixDepth(depth);
                // Console.Write(candidate);
                // Console.WriteLine(" <---");
                var messagesKnownNew = new string[2];
                var messagesOriginalNew = new string[2];
                messagesKnownNew[1] = messagesKnown[0];
                messagesKnownNew[0] = messagesKnown[1];
                messagesKnownNew[0] += candidate;
                messagesOriginalNew[1] = messagesOriginal[0];
                messagesOriginalNew[0] = messagesOriginal[1];
                if (messagesKnownNew[0].Length != messagesOriginalNew[0].Length)
                {
                    messagesKnownNew[0] += " ";
                }
                var results = AttackSubString(messagesKnownNew, messagesOriginalNew, string.Concat(keyKnown), depth + 1);
                foreach (var result in results)
                {
                    candidates.Add(result);
                }
            }
            catch(IndexOutOfRangeException)
            {
            }
        }
        
        return candidates.ToArray();
    }
    // Assumes that the messages have been encrypted with the same key.
    // Returns the possible keys.
    // The known string is assumed to be at the start of the first item.
    // The array must be at least 2 items long, but only the first two items are used.
    public static string[] AttackSameKey(string[] messages, string known)
    {
        var knownItems = new string[messages.Length];
        knownItems[0] = known + " ";
        knownItems[1] = "";
        var candidates = AttackSubString(knownItems, messages, "", 0);
        return candidates;
    }
}