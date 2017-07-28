using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerUI ui;
    [SerializeField] private GameInput gameInput = new GameInput();
    [SerializeField] private float healthTotal = 5;
    [SerializeField] private float health = 5;
    [SerializeField] private int hitsDamage = 0;

    [Header("Timer:")]
    [SerializeField] private float timerLimit = 2;
    private float timer = 3f;
    private bool isCooldown = false;
    [SerializeField] private bool isCooldownControl = false;


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
<<<<<<< Updated upstream
        Time.timeScale = 1;
        restart = false;
=======
>>>>>>> Stashed changes
        health = healthTotal;
        ui.Lifebar = 1;
        ui.Cooldown = 1;
        timer = timerLimit;
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
        if (inputTimeDecrease > 0 && !isCooldown)
        {
            timer -= Time.deltaTime;
            ui.Cooldown = timer / timerLimit;
            timeSense.gameObject.SetActive(true);
            if (timer <= 0)
            {
                timer = 0;
                ui.Cooldown = 0;
                isCooldown = true;
            }
        }
        else
        {
            if (!isCooldown && !isCooldownControl)
                isCooldown = true;

            timer += Time.deltaTime;
            ui.Cooldown = timer / timerLimit;
            timeSense.gameObject.SetActive(false);
            if (timer > timerLimit)
            {
                timer = timerLimit;
                isCooldown = false;
            }
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
            ui.Lifebar = health / healthTotal;

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
