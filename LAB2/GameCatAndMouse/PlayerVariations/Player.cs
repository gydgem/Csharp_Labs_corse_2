namespace LAB2.GameCatAndMouse.PlayerVariations;

public enum StatePlayer
{
    Winner,
    Looser,
    Playing,
    NotInGame
}

public class Player(int position, int positionMax, int distanceTraveled, StatePlayer state)
{
    private int _position = position;
    private int _distanceTraveled = distanceTraveled;
    private StatePlayer _state = state;

    public virtual void Move(int direction)
    {
        if (_state == StatePlayer.Playing)
        {
            _position = ((_position + direction) % positionMax + positionMax) % positionMax;
            _distanceTraveled += int.Abs(direction);
        }
    }

    public int GetDistanceTraveled()
    {
        return _distanceTraveled;
    }

    public int GetPosition()
    {
        return _position;
    }

    public StatePlayer GetState()
    {
        return _state;
    }

    public void SetState(StatePlayer state)
    {
        _state = state;
    }

    public void SetPosition(int position)
    {
        this._position = position;
    }
}