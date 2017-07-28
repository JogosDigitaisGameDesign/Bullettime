﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    private GameInput gameInput = new GameInput();
    [SerializeField]
    private int health = 5;
    [SerializeField]
    private int hitsDamage = 0;

    private MoveControl moveControl;
    private Weapon weapon;

    private float inputForward = 0;
    private float inputTurn = 0;
    private float inputRotationY = 0;
    private float inputJump = 0;
    private float inputRun = 0;
    private float inputTimeIncrease = 0;
    private float inputTimeDecrease = 0;
    private bool restart = false;

    public TimeSense timeSense = null;
    private bool inputActivateTimeSense = false;
    private bool inputShoot = false;

    //public GameObject bullet;

    public float fireRate = 1f;
    public float lastShot = 0.0f;

    // Use this for initialization
    void Start()
    {
        moveControl = GetComponent<MoveControl>();
        weapon = GetComponent<Weapon>();
        timeSense.gameObject.SetActive(false);
        Time.timeScale = 1;
        restart = false;
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
        inputShoot = gameInput.Shoot;
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
            timeSense.gameObject.SetActive(true);
        else
        {
            //timeSense.Release();
            timeSense.gameObject.SetActive(false);
        }

        if (inputShoot)
            weapon.efetuarDisparo();

        moveControl.Jump(inputJump);
        moveControl.Move(inputForward, inputTurn, inputRotationY, inputRun);

        if (Input.GetKey(KeyCode.Q))
        {
            //Fire();
        }



    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "Enemy")
        {
            health--;
            hitsDamage++;
            if(health <= 0)
            {
                Time.timeScale = 0;
                restart = true;
            }
               
        }
    }

    void OnGUI()
    {
        if (restart && GUI.Button(new Rect(300, 70, 100, 50), "Restart"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    //void Fire()
    //{
    //    if (Time.time > fireRate + lastShot)
    //    {
    //        Instantiate(bullet, transform.position, Quaternion.identity);
    //        lastShot = Time.time;
    //    }
    //}


    //public void ativarBolha(GameObject timeSense)
    //{


    //    if (timeSense.activeSelf)
    //        timeSense.SetActive(false);
    //    else if (timeSense.activeSelf == false)
    //        timeSense.SetActive(true);
    //}
}
