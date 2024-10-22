using LAB2.GameCatAndMouse.PlayerVariations;

namespace LAB2.GameCatAndMouse;

public class GameField(int sizeField, PlayerCat playerCat, PlayerMouse playerMouse)
{
    private PlayerCat _playerCat = playerCat;
    private PlayerMouse _playerMouse = playerMouse;

    int GetSizeField()
    {
        return sizeField;
    }
    
    public int? GetDistanceBetweenCatAndMouse()
    {
        if (_playerCat.GetState() == StatePlayer.NotInGame ||
            _playerMouse.GetState() == StatePlayer.NotInGame)
        {
            return null;
        }

        return int.Abs((int)(_playerCat.GetPosition() - _playerMouse.GetPosition()));
    }
}