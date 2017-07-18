using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private GameInput gameInput = new GameInput();
    private MoveControl moveControl;

    private float inputForward = 0;
    private float inputTurn = 0;
    private float inputRotationY = 0;
    private float inputJump = 0;
    private float inputRun = 0;
    private float inputTimeIncrease = 0;
    private float inputTimeDecrease = 0;
    [SerializeField]
    private float timeScale = 0;

    // Use this for initialization
    void Start()
    {
        timeScale = Time.timeScale;
        moveControl = GetComponent<MoveControl>();
    }

    private void GetInputs()
    {
        inputForward = gameInput.Forward;
        inputTurn = gameInput.Turn;
        inputRotationY = gameInput.RotationY;
        inputJump = gameInput.Jump;
        inputRun = gameInput.Run;
        inputTimeIncrease = gameInput.TimeIncrease;
        inputTimeDecrease = gameInput.TimeDecrease;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        if (inputTimeIncrease > 0)// && (Time.timeScale + inputTimeIncrease > 0))
            Time.timeScale += inputTimeIncrease * 0.01f;
        else if (inputTimeDecrease > 0)// && (Time.timeScale - inputTimeDecrease) > 0)
            Time.timeScale -= inputTimeDecrease * 0.01f;
        if (timeScale < 0)
            timeScale = 0;

        timeScale = Time.timeScale;

        moveControl.Jump(inputJump);
        moveControl.Move(inputForward, inputTurn, inputRotationY, inputRun);
    }

}
