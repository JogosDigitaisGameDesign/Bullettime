using UnityEngine;
using System;

[Serializable]
public class GameInput {

    [SerializeField] private string vertical = "Vertical";
    [SerializeField] private string horizontal = "Horizontal";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string run = "Run";

    public float Vertical { get {return Input.GetAxis(vertical);} }
    public float Horizontal { get { return Input.GetAxis(horizontal); } }
    public float Jump { get { return Input.GetAxis(jump); } }
    public float Run { get { return Input.GetAxis(run); } }

}
