using LAB2.GameCatAndMouse.PlayerVariations;

namespace LAB2.GameCatAndMouse;

enum GameState
{
    Start,
    Runing,
    End,
    Error
}

public class IOFileGame
{
    private PlayerCat _playerCat = null;
    private PlayerMouse _playerMouse = null;
    private GameField _gameField = null;
    private GameState _gameState = GameState.Start;
    private TextReader _inputCommandReader = null!;
    private TextWriter _outputWriter = null!;
    OutputFormatInFile _outputFormat = null!;

    private void MovePlayerOrSetStartPosition(Player player, int direction)
    {
        if (player.GetState() == StatePlayer.NotInGame)
        {
            player.SetState(StatePlayer.Playing);
            player.SetPosition(direction);
        }
        else if (player.GetState() == StatePlayer.Playing)
        {
            player.Move(direction);
        }
    }

    private void ProcessCommand(string command, int argument)
    {
        switch (command)
        {
            case "C":
                MovePlayerOrSetStartPosition(_playerCat, argument);
                break;
            case "M":
                MovePlayerOrSetStartPosition(_playerMouse, argument);
                break;
            default:
                throw new Exception("Error: Invalid command");
        }
    }

    private void ProcessCommand(string command)
    {
        switch (command)
        {
            case "P":
                if (_playerCat.GetState() == StatePlayer.NotInGame || _playerCat.GetState() == StatePlayer.Playing)
                    _outputFormat.PrintBody(
                        _playerCat.GetState() == StatePlayer.Playing ? _playerCat.GetPosition() : null,
                        _playerMouse.GetState() == StatePlayer.Playing ? _playerMouse.GetPosition() : null,
                        _gameField.GetDistanceBetweenCatAndMouse());
                break;
            default:
                throw new Exception("Error: Invalid command");
        }
    }

    private void RunGame()
    {
        _outputFormat.PrintСap();
        string? line = null;
        while (_gameState == GameState.Runing && (line = _inputCommandReader.ReadLine()) != null)
        {
            string[] parts = line.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (parts.Length == 1)
                {
                    ProcessCommand(parts[0]);
                }
                else if (parts.Length == 2)
                {
                    ProcessCommand(parts[0], int.Parse(parts[1]));
                }
                else
                {
                    throw new Exception("Error: Invalid command");
                }
            }
            catch (Exception e)
            {
                _gameState = GameState.Error;
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        if (_gameState == GameState.Runing)
        {
            _outputFormat.PrintFeet(_playerCat.GetDistanceTraveled(),
                _playerMouse.GetDistanceTraveled(),
                (_playerCat.GetState() == StatePlayer.Winner ? _playerCat.GetPosition() : null));
            _gameState = GameState.End;
        }
    }

    private void CreatingPlayersAndFields(int sizeField)
    {
        _playerCat = new PlayerCat(0, sizeField, 0, StatePlayer.NotInGame);
        _playerMouse = new PlayerMouse(0, sizeField, 0, StatePlayer.NotInGame);
        _playerCat.LincPlayerMouse(_playerMouse);
        _playerMouse.LincPlayerCat(_playerCat);
        _gameField = new GameField(sizeField, _playerCat, _playerMouse);
    }

    private bool OpenFileInputAndOutput(string pathToInput, string pathToOutput)
    {
        if (!File.Exists(pathToInput))
        {
            _gameState = GameState.Error;
            Console.WriteLine("Error: Input file does not exist.");
            return false;
        }

        try
        {
            _inputCommandReader = new StreamReader(pathToInput);
            _outputWriter = new StreamWriter(pathToOutput);
            _outputFormat = new OutputFormatInFile(_outputWriter);

            if (_inputCommandReader == null || _outputWriter == null)
            {
                _gameState = GameState.Error;
                Console.WriteLine("Error: Failed to open input or output stream.");
                return false;
            }
        }
        catch (Exception e)
        {
            _gameState = GameState.Error;
            Console.WriteLine($"Error: {e.Message}");
            return false;
        }

        return true;
    }

    private void CloseFileInputAndOutput()
    {
        _inputCommandReader?.Dispose();
        _outputWriter?.Dispose();
    }

    public IOFileGame(string pathToInput, string pathToOutput)
    {
        if (!OpenFileInputAndOutput(pathToInput, pathToOutput))
        {
            return;
        }

        int sizeField = int.Parse(_inputCommandReader.ReadLine().Trim());
        CreatingPlayersAndFields(sizeField);

        _gameState = GameState.Runing;
        RunGame();
        CloseFileInputAndOutput();
    }
}