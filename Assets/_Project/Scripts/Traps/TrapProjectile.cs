using UnityEngine;
using System.Collections;
using System;

public class TrapProjectile : ITrap {
    [SerializeField] private float damage = 3;
    [SerializeField] private float speed = 3;
    [SerializeField] private float timerDestroy = 1.5f;
    [SerializeField] private bool permissionRespawn = true;
    [SerializeField] private bool directionRespawnPoint = true;
    [SerializeField] private bool touchDestroy = true;
    [SerializeField] private Vector3 arrowDirection = Vector3.forward;

    private TimeBehaviour timeBehaviout = null;
    
    private float timer = 0;
    private bool isCollided = false;
    private Rigidbody rbody;

    public override float TimeInfluence { get { return base.TimeInfluence; }
        set {
            base.TimeInfluence = value;
            if (timeBehaviout != null)
                timeBehaviout.TimeInfluence = value;
        }
    }

    // Use this for initialization
    void Start () {
        Begin();
    }

	// Update is called once per frame
	void Update () {

        PlayAudio();
        Run();
	}

    private void OnCollisionEnter(Collision outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Player")
        {
            //danificar(outro.gameObject.GetComponent<PlayerControl>());
        }

        rbody.useGravity = true;
        rbody.AddForce(Vector3.zero, ForceMode.Acceleration);
        isCollided = true;

        if (touchDestroy)
        {
            Destroy(gameObject);
        }
        else
            damage = 0;
    }

    private void danificar(PlayerControl jogador)
    {
        //jogador.decrementarHP(dano);
    }

    public override void Begin()
    {
        rbody = GetComponent<Rigidbody>();
        timeBehaviout = GetComponent<TimeBehaviour>();

        IsRespawn = permissionRespawn;
        if (!directionRespawnPoint)
        {
            Direction = arrowDirection;
        }
    }

    public void Run()
    {
        if (IsActivated)
        {
            if (!isCollided)
            {
                // mover
                //transform.localPosition += Direcao * velocidade * Time.deltaTime;
                rbody.AddForce(Direction * speed, ForceMode.Impulse);
                isCollided = true;
            }   
            // Controlar tempo
            timer += Time.deltaTime;
            if (timer > timerDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}