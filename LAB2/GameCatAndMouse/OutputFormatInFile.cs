namespace LAB2.GameCatAndMouse;

public class OutputFormatInFile(TextWriter outputWriter)
{
    private readonly string _lineSeparator = new string('-', 30);

    public void PrintСap()
    {
        outputWriter.WriteLine($"{"Cat",-10}{"Mouse",-10}{"Distance",-10}");
        outputWriter.WriteLine(_lineSeparator);
    }

    public void PrintBody(int? cat, int? mouse, int? distance)
    {
        outputWriter.WriteLine("{0,-10}{1,-10}{2,-10}", 
            cat == null ? "??" : cat,
            mouse == null ? "??" : mouse,
            distance);
    }

    public void PrintFeet(int? catDistanceTraveled, int? mouseDistanceTraveled, int? positionOfTheCaughtMouse)
    {
        outputWriter.WriteLine(_lineSeparator);
        outputWriter.WriteLine();
        outputWriter.WriteLine($"{"Distance traveled:",-20}{"Cat",-10}{"Mouse",-10}");
        outputWriter.WriteLine("{0,-20}{1,-10}{2,-10}", "", catDistanceTraveled, mouseDistanceTraveled);
        outputWriter.WriteLine();
        
        if (positionOfTheCaughtMouse == null)
        {
            outputWriter.WriteLine("Mouse evaded Cat");
        }
        else
        {
            outputWriter.WriteLine("Mouse caught at: " + positionOfTheCaughtMouse);
        }
    }
}