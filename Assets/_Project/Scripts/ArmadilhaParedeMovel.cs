using UnityEngine;
using System.Collections;
using System;

public class ArmadilhaParedeMovel : ITrap {
    [SerializeField] private float dano = 1;
    [SerializeField] private bool m_mortal = false;
    [SerializeField] private bool pararAoToque = true;
    [SerializeField] private bool retornoAutomatico = true;
    private bool mexer = true;

    [SerializeField] private float velocidade = 0.5f;
    [SerializeField] private float intervaloMovimentacao = 0.5f;
    [SerializeField] private float distanciaMaxima = 6;
    private float deslocamentoZ = 0;
    private float deslocamentoMax = 0;
    private bool positivo = true;
    private float tempo = 0;
    private bool trocarSentido = false;
    
    private Vector3 forward = Vector3.zero;

    private bool encostaJogador = false;

    public bool isEncostandoJogador { get { return encostaJogador; } set { encostaJogador = value; } }

    // Use this for initialization
    void Start () {
        Begin();
    }
	
	// Update is called once per frame
	void Update () {
        // Audio

        PlayAudio();
        Run();
    }

    private void OnCollisionEnter(Collision outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Player")
        {
            //PlayerControl jogador = outro.gameObject.GetComponent<Personagem>();
            //causarDano(jogador);
            encostaJogador = true;
        }
    }

    private void OnCollisionStay(Collision outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Jogador")
        {
            //PlayerControl jogador = outro.gameObject.GetComponent<PlayerControl>();
            //causarDano(jogador);
            encostaJogador = true;
        }
    }

    private void OnCollisionExit(Collision outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Jogador")
        {
            encostaJogador = false;
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        string auxTag = outro.gameObject.tag;

        if (auxTag == "Jogador")
        {
            //PlayerControl jogador = outro.gameObject.GetComponent<PlayerControl>();
            //causarDano(jogador);
        }
    }



    private void causarDano(PlayerControl jogador)
    {
        //if (m_mortal)
        //{
        //    float vidaJogador = jogador.HP;
        //    jogador.decrementarHP(vidaJogador + 1);
        //}
        //else
        //{
        //    jogador.decrementarHP(dano);
        //}
    }

    private void mover()
    {
        tempo += Time.deltaTime;
        if (tempo > intervaloMovimentacao)
        {
            tempo = 0;
            // mover
            transform.localPosition += forward * velocidade * Time.deltaTime;

            deslocamentoZ = valorDirecaoVetor();

            if (positivo)
            {
                if (deslocamentoZ >= deslocamentoMax)
                {
                    transform.localPosition = ajustaPosicaoFinal();
                    mexer = false;
                    desativarArmadilha();
                }
            }
            else
            {
                if (deslocamentoZ <= deslocamentoMax)
                {
                    transform.localPosition = ajustaPosicaoFinal();
                    mexer = false;
                    desativarArmadilha();
                }
            }
        }
    }

    private void desativarArmadilha()
    {

        if (trocarSentido)
        {
            mexer = true;
            deslocamentoZ = 0;
            deslocamentoMax = 0;
            positivo = true;
            tempo = 0;
            trocarSentido = false;
            forward = Vector3.zero;
            encostaJogador = false;
            IsActivated = false;

            Begin();
        }
    }
public override void Begin()
    {
        IsRespawn = false;

        forward = transform.forward;
        //bloquearEixosRB();

        deslocamentoZ = valorDirecaoVetor();
        positivo = sentido();

        if (positivo)
        {
            deslocamentoMax = deslocamentoZ + distanciaMaxima;
        }
        else
        {
            deslocamentoMax = deslocamentoZ - distanciaMaxima;
        }
    }



    public void Run()
    {
        if (IsActivated)
        {
            if (mexer) {
                if (pararAoToque)
                {
                    if (!isEncostandoJogador)
                    {
                        mover();
                    }
                }
                else
                    mover();
            }
            else
            {
                if (retornoAutomatico)
                {
                    retornar();
                }
            }
        }
    }


    private void retornar()
    {
        trocarSentido = true;
        mexer = true;
        IsRespawn = false;
        forward = transform.forward * -1;

        deslocamentoZ = valorDirecaoVetor();
        positivo = sentido();

        if (positivo)
        {
            deslocamentoMax = deslocamentoZ + distanciaMaxima;
        }
        else
        {
            deslocamentoMax = deslocamentoZ - distanciaMaxima;
        }
    }


    private float valorDirecaoVetor()
    {
        if (Mathf.Abs(forward.x) >= 0.9f && Mathf.Abs(forward.x) <= 1.1f)
        {
            return transform.localPosition.x;
        }else if (Mathf.Abs(forward.y) >= 0.9f && Mathf.Abs(forward.y) <= 1.1f)
        {
            return transform.localPosition.y;
        }
        else if (Mathf.Abs(forward.z) >= 0.9f && Mathf.Abs(forward.z) <= 1.1f)
        {
            return transform.localPosition.z;
        }
        return 0;
    }

    private Vector3 ajustaPosicaoFinal()
    {
        Vector3 posicaoFinal = Vector3.zero;

        if (Mathf.Abs(forward.x) >= 0.9f && Mathf.Abs(forward.x) <= 1.1f)
        {
            posicaoFinal = new Vector3(deslocamentoMax, transform.localPosition.y, transform.localPosition.z);
        }
        else if (Mathf.Abs(forward.y) >= 0.9f && Mathf.Abs(forward.y) <= 1.1f)
        {
            posicaoFinal = new Vector3(transform.localPosition.x, deslocamentoMax, transform.localPosition.z);
        }
        else if (Mathf.Abs(forward.z) >= 0.9f && Mathf.Abs(forward.z) <= 1.1f)
        {
            posicaoFinal = new Vector3(transform.localPosition.x, transform.localPosition.y, deslocamentoMax);
        }
        return posicaoFinal;
    }

    private bool sentido()
    {
        float valor = forward.x + forward.y + forward.z;

        if (valor >= 0)
        {
            return true;
        }
        return false;
    }
}
