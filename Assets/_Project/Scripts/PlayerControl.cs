using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private GameInput gameInput = new GameInput();
    private MoveControl moveCotnrol = null;

    private float inputHorizontal = 0;
    private float inputVeritical = 0;
    private float inputJump = 0;
    private float inputRun = 0;
    private MoveControl moveControl;

    // Use this for initialization
    void Start()
    {
        moveControl = GetComponent<MoveControl>();
    }

    private void GetInputs()
    {
        inputHorizontal = gameInput.Horizontal;
        inputVeritical = gameInput.Vertical;
        inputJump = gameInput.Jump;
        inputRun = gameInput.Run;

        if (inputRun >= 0)
            moveControl.Speed = moveControl.SpeedRun;
        else
            moveControl.Speed = moveControl.SpeedWalk;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        if (inputHorizontal <= 0)
            moveControl.Stop();
        else
            moveControl.Move();
    }
}
