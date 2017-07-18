using UnityEngine;
using System;

[Serializable]
public class GameInput
{
    [SerializeField] private string forward = "Vertical";
    [SerializeField] private string turn = "Horizontal";
    [SerializeField] private string rotationY = "Mouse X";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string run = "Run";
    [SerializeField] private string timeIncrease = "Time Increase";
    [SerializeField] private string timeDecrease = "Time Decrease";

    public float Forward { get { return Input.GetAxis(forward); } }
    public float Turn { get { return Input.GetAxis(turn); } }
    public float RotationY { get { return Input.GetAxis(rotationY); } }
    public float Jump { get { return Input.GetAxis(jump); } }
    public float Run { get { return Input.GetAxis(run); } }
    public float TimeIncrease{get { return Input.GetAxis(timeIncrease); }}
    public float TimeDecrease { get { return Input.GetAxis(timeDecrease); }}
}
