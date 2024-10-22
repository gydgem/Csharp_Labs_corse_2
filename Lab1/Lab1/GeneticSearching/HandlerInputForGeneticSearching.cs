namespace Lab1.GeneticSearching;

public class HandlerInputForGeneticSearching
{
    public static  List<GeneticData>  inputDataSequencesFromFilePath(string filePath)
    {
        List<GeneticData> dataSequences = new List<GeneticData>();
        
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            
            while ((line = reader.ReadLine()) != null)
            {
                string[] fragments = line.Split('\t');
                GeneticData exemplar;
                exemplar.nameProtein = fragments[0];
                exemplar.nameOrganism = fragments[1];
                exemplar.aminoAcidSequence = fragments[2];
                dataSequences.Add(exemplar);
            }
        }
        
        return dataSequences;
    }

    public static  List<CommandsData> inputDataCommandsFromFilePath(string filePath)
    {
        List<CommandsData> dataSequences = new List<CommandsData>();
        
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            
            while ((line = reader.ReadLine()) != null)
            {
                string[] fragments = line.Split('\t');
                CommandsData command;
                command.command = fragments[0];
                command.commandArgs = fragments.Skip(1).ToArray();
                dataSequences.Add(command);
            }
        }
        
        return dataSequences;
    }
}