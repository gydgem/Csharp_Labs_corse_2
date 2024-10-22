// See https://aka.ms/new-console-template for more information

using LAB2.GameCatAndMouse;

class Program
{
    static int Main(string[] args)
    {
        IOFileGame ioFileGame = new IOFileGame("data/1.ChaseData.txt", "./data/Res1.txt");
        IOFileGame ioFileGame1 = new IOFileGame("data/2.ChaseData.txt", "./data/Res2.txt");
        IOFileGame ioFileGame2 = new IOFileGame("data/3.ChaseData.txt", "./data/Res3.txt");
       
        return 0;
    }
}

