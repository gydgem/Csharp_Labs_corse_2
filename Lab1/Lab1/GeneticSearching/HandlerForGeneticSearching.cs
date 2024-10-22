namespace Lab1.GeneticSearching
{
    public class GeneticSearchingHandler
    {
        private string pathToSequencesData;
        private string pathToCommandsData;
        private string pathToCommandsResultData;

        private void processComand(CommandsData command, List<GeneticData> geneticData)
        {
            switch (command.command)
            {
                case "search":
                    break;
                case "diff":
                    break;
                case "mode":
                    break;
                default:
                    throw new ArgumentNullException(command.command);
            }
        }

        public GeneticSearchingHandler(
            string pathToSequencesData, 
            string pathToCommandsData,
            string pathToCommandsResultData) 
        {
            this.pathToSequencesData = pathToSequencesData;
            this.pathToCommandsData = pathToCommandsData;
            this.pathToCommandsResultData = pathToCommandsResultData;
        }
        
        public void process()
        {
            List<GeneticData> geneticData = 
                HandlerInputForGeneticSearching.inputDataSequencesFromFilePath(pathToSequencesData);
            List<CommandsData> commandsData =
                HandlerInputForGeneticSearching.inputDataCommandsFromFilePath(pathToSequencesData);
            foreach (var command in commandsData)
            {
                processComand(command, geneticData);
            }
        }
    }
}