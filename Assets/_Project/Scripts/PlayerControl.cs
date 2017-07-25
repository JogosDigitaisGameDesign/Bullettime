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

    public GameObject timeSense = null;
    private bool inputActivateTimeSense = false;

    public GameObject bullet;

    public float fireRate = 1f;
    public float lastShot = 0.0f;

    // Use this for initialization
    void Start()
    {
        moveControl = GetComponent<MoveControl>();
        timeSense.SetActive(false);
    }

    private void GetInputs()
    {
        inputForward = gameInput.Forward;
        inputTurn = gameInput.Turn;
        //inputRotationY = gameInput.RotationY;
        inputJump = gameInput.Jump;
        inputRun = gameInput.Run;
        inputTimeIncrease = gameInput.TimeIncrease;
        inputTimeDecrease = gameInput.TimeDecrease;
        inputActivateTimeSense = gameInput.ActivateTimeSense;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        //if (inputTimeIncrease > 0)
        //{
        //    timeScale += inputTimeIncrease * 0.01f;
        //}
        //else 
        if (inputTimeDecrease > 0)
            timeSense.SetActive(true);
        else
            timeSense.SetActive(false);

        moveControl.Jump(inputJump);
        moveControl.Move(inputForward, inputTurn, inputRotationY, inputRun);

        if (Input.GetKey(KeyCode.Q))
        {
            Fire();
        }
            


    }

    void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            lastShot = Time.time;
        }
    }


    //public void ativarBolha(GameObject timeSense)
    //{


    //    if (timeSense.activeSelf)
    //        timeSense.SetActive(false);
    //    else if (timeSense.activeSelf == false)
    //        timeSense.SetActive(true);
    //}
}
