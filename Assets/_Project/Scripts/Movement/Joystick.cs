using UnityEngine;

[System.Serializable]
public struct Joystick 
{
    [SerializeField] private InputButton _up;
    [SerializeField] private InputButton _down;
    [SerializeField] private InputButton _left;
    [SerializeField] private InputButton _right;

    public InputButton Up => _up;
    public InputButton Down => _down;
    public InputButton Left => _left;
    public InputButton Right => _right;

    public bool AnyPressed
    {
        get
        {
            return _up.Active | _down.Active | _left.Active | _right.Active;
        }
    }

}