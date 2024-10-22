namespace LAB2.GameCatAndMouse.PlayerVariations;

public class PlayerCat(int position, int positionMax, int distanceTraveled, StatePlayer state)
    : PlayerVariations.Player(position, positionMax, distanceTraveled, state)
{
    private PlayerMouse? _playerMouse = null;

    public void LincPlayerMouse(PlayerMouse? playerMause)
    {
        _playerMouse = playerMause;

        _playerMouse?.CheckAndUpdateState(this);
    }

    public override void Move(int direction)
    {
        base.Move(direction);

        _playerMouse?.CheckAndUpdateState(this);
    }
}