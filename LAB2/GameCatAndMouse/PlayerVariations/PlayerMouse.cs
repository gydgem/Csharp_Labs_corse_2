namespace LAB2.GameCatAndMouse.PlayerVariations;

public class PlayerMouse(int position, int positionMax, int distanceTraveled, StatePlayer state)
    : PlayerVariations.Player(position, positionMax, distanceTraveled, state)
{
    private PlayerCat? _playerCat = null;

    public void CheckAndUpdateState(PlayerCat playerCat)
    {
        if (GetState() == StatePlayer.NotInGame || playerCat.GetState() == StatePlayer.NotInGame)
        {
            return;
        }

        int? positionMouse = GetPosition();
        int? positionCat = playerCat.GetPosition();
        if (positionMouse == positionCat)
        {
            playerCat.SetState(StatePlayer.Winner);
            SetState(StatePlayer.Looser);
        }
    }

    public void LincPlayerCat(PlayerCat? playerMouse)
    {
        _playerCat = playerMouse;
        if (_playerCat != null)
            CheckAndUpdateState(_playerCat);
    }

    public override void Move(int direction)
    {
        base.Move(direction);
        if (_playerCat != null)
            CheckAndUpdateState(_playerCat);
    }
}