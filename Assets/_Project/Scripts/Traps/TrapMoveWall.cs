using UnityEngine;
using System.Collections;
using System;

public class TrapMoveWall : ITrap {
    [SerializeField] private float damage = 1;
    [SerializeField] private bool autoReturn = true;
    private bool isMove = true;

    [SerializeField] private float speed = 100f;
    
    private Vector3 forward = Vector3.zero;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        // Audio
        //executarAudio();
        Run();
    }

    private void OnCollisionEnter(Collision other)
    {
        string auxTag = other.gameObject.tag;

        if (auxTag == "Player")
        {
            PlayerControl player = other.gameObject.GetComponent<PlayerControl>();
            //causarDano(player);
        }
    }

    private void OnCollisionStay(Collision outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Player")
        {
            PlayerControl player = outro.gameObject.GetComponent<PlayerControl>();
            //causarDano(player);
        }
    }

    private void OnCollisionExit(Collision outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Player")
        {
            //encostaJogador = false;
        }
    }


    private void DamagePlayer(PlayerControl player)
    {
        //player.decrementarHP(damage);
    }

    private void Move()
    {

    }

    private void desativarArmadilha()
    {
        //if (trocarSentido)
        //{
        //    isMove = true;
        //    deslocamentoZ = 0;
        //    deslocamentoMax = 0;
        //    positivo = true;
        //    timerMove = 0;
        //    trocarSentido = false;
        //    forward = Vector3.zero;
        //    encostaJogador = false;
        //    IsActivated = false;

        //    iniciar();
        //}
    }
public override void Begin()
    {
        base.Begin();
        IsRespawn = false;

        forward = transform.forward;
        //bloquearEixosRB();

        //deslocamentoZ = valorDirecaoVetor();
        //positivo = sentido();

        //if (positivo)
        //{
        //    deslocamentoMax = deslocamentoZ + distanciaMaxima;
        //}
        //else
        //{
        //    deslocamentoMax = deslocamentoZ - distanciaMaxima;
        //}
    }



    public void Run()
    {
        if (IsActivated)
        {
            
        }
    }


    private void retornar()
    {
        //trocarSentido = true;
        //isMove = true;
        //IsRespawn = false;
        //forward = transform.forward * -1;

        //deslocamentoZ = valorDirecaoVetor();
        //positivo = sentido();

        //if (positivo)
        //{
        //    deslocamentoMax = deslocamentoZ + distanciaMaxima;
        //}
        //else
        //{
        //    deslocamentoMax = deslocamentoZ - distanciaMaxima;
        //}
    }


    private float DirectionForwardValue()
    {
        if (forward.x != 0)
            return transform.localPosition.x;
        else if (forward.y != 0)
            return transform.localPosition.y;
        else if (forward.z != 0)
            return transform.localPosition.z;
        return 0;
    }


    private bool Orientation()
    {
        float value = forward.x + forward.y + forward.z;

        if (value >= 0)
            return true;
        return false;
    }
}
