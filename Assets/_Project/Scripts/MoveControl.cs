using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
public class MoveControl : MonoBehaviour
{
    private CharacterController charControl = null;
    [SerializeField]
    private float speedWalk = 10;
    [SerializeField]
    private float speedRun = 20;
    [SerializeField]
    private float speedRotation = 1;
    [SerializeField]
    private float speedJump = 30;
    [SerializeField]
    private float gravityMultiply = 1;
    private float speedActual = 0;
    private Vector3 speed = Vector2.zero;
    //private bool isJump = false;


    #region Properties
    public float SpeedWalk { get { return speedWalk; } }
    public float SpeedRun { get { return speedRun; } }
    #endregion

    public void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stop()
    {
        speedActual = 0;
        speed = Vector3.zero;
    }

    public void Move(float inputForward, float inputTurn, float inputRotationY, float inputRun)
    {
        // Efetuar movimentação e rotação em Y
        //transform.Rotate(0, inputRotationY * speedRotation, 0);
        transform.Rotate(0, inputTurn * speedRotation, 0);

        // Efetuar rotação em X
        //orientacao.Rotate(-entVirarX * speedRotation, 0, 0);

        // Efetuar delocamento no cenário
        Vector3 auxSpeed = Vector3.zero;
        if (inputRun > 0)
            speedActual = speedRun;
        else
            speedActual = speedWalk;

        if (inputForward > 0 && inputTurn > 0)
        {
            auxSpeed.z = 0.5f;// (inputForward * speedActual) / 2;
            auxSpeed.x = 0.5f; // (inputTurn * speedActual) / 2;
        }
        else
        {
            auxSpeed.z = 1; // inputForward * speedActual;
            auxSpeed.x = 1; // inputTurn * speedActual;
        }
        speed.z = auxSpeed.z * inputForward * speedActual;
        //speed.x = auxSpeed.x * inputTurn * speedActual;

        charControl.Move(transform.TransformDirection(speed * Time.deltaTime));
    }

    public void Jump(float inputJump)
    {
        // fora da área do chão
        /*
        if (transform.position.y > chaoAtual + charCtrl.stepOffset ||
            transform.position.y < chaoAtual - charCtrl.stepOffset)
        {
            noChao = false;
        }
        */
        // Verifica se está no chão

        if (charControl.isGrounded)
        {
            //noChao = true;
            //chaoAtual = transform.position.y; // Pega posição atual do chão

            // Saltou?
            speed.y = 0;
            if (inputJump != 0)
            {
                speed.y = speedJump;
                //isJump = true;
            }
        }
        //Debug.Log(distancia);
        speed.y += Physics.gravity.y * gravityMultiply * Time.deltaTime;
    }


}
