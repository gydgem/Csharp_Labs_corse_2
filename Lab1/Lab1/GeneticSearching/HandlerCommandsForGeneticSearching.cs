using System.Security.Cryptography;

namespace Lab1.GeneticSearching;

public class HandlerCommandsForGeneticSearching
{
    public static List<GeneticData> searh(List<GeneticData> geneticData, string value)
    {
        List<GeneticData> result = new List<GeneticData>();
        
        foreach (var data in geneticData)
        {
            if (data.aminoAcidSequence.Contains(value))
            {
                result.Add(data);
            }
        }
        
        return result;
    }

    public static long diff(string aminoAcidSequenceFirst, string aminoAcidSequenceSecond)
    {
        if (EncoderForGeneticSearching.isEncoded(aminoAcidSequenceFirst))
        {
            throw new ArgumentException("aminoAcidSequenceFirst is encoded", nameof(aminoAcidSequenceFirst));
        }
    
        if (EncoderForGeneticSearching.isEncoded(aminoAcidSequenceSecond))
        {
            throw new ArgumentException("aminoAcidSequenceSecond is encoded", nameof(aminoAcidSequenceSecond));
        }
        
        long differences = Math.Abs(aminoAcidSequenceFirst.Length - aminoAcidSequenceSecond.Length);
        int minLength = Math.Min(aminoAcidSequenceFirst.Length, aminoAcidSequenceSecond.Length);
        
        for (int i = 0; i < minLength; i++)
        {
            if (aminoAcidSequenceFirst[i] != aminoAcidSequenceSecond[i])
            {
                differences++;
            }
        }

        return differences;
    }

    public static (char aminoAcid, long amount) mode(string aminoAcidSequence)
    {
        if (EncoderForGeneticSearching.isEncoded(aminoAcidSequence))
        {
            throw new ArgumentException("aminoAcidSequence is encoded", nameof(aminoAcidSequence));
        }
        
        
    }
    
}