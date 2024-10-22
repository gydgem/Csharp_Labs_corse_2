using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Lab1.GeneticSearching;

public class EncoderForGeneticSearching
{
    public string decode(string aminoAcidSequence)
    {
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < aminoAcidSequence.Length; i++)
        {
            char currentChar = aminoAcidSequence[i];
            result.Append(currentChar);
            
            if (i + 1 < aminoAcidSequence.Length && char.IsDigit(aminoAcidSequence[i + 1]))
            {
                result.Append(new string(currentChar, aminoAcidSequence[i + 1] - '0')); 
                i++;
            }
        }
        
        return result.ToString();
    }

    public static string encode(string aminoAcidSequence)
    {
        StringBuilder result = new StringBuilder();
        
        for (int i = 1, count = 1; i <= aminoAcidSequence.Length; i++)
        {
            if (i < aminoAcidSequence.Length && aminoAcidSequence[i] == aminoAcidSequence[i - 1])
            {
                count++;
            }
            else
            {
                if (count > 2)
                {
                    result.Append(count);
                }
                result.Append(aminoAcidSequence[i - 1]);
                count = 1;
            }
        }
        return result.ToString();
    }

    public static bool isEncoded(string aminoAcidSequence)
    {
        return aminoAcidSequence.Any(char.IsDigit);
    }

    public static bool isDecoded(string aminoAcidSequence)
    {
        return !aminoAcidSequence.Any(char.IsDigit);
    }
}