using UnityEngine;
using System.Collections;
using System;

public class Trapdoor : ITrap {
    [SerializeField] private Transform doorRigth = null;
    [SerializeField] private Transform doorLeft = null;
    [SerializeField] private Vector3 rotation = new Vector3(0,0,90);

    [SerializeField] private float speedOpen = 3;
    [SerializeField] private float speedClose = 1;
    private float speedOp = 3;
    private float speedCl = 1;
    private float timeInfluence = 1;

    [SerializeField] private bool isClose = true;
    [SerializeField] private bool manterPortas = true;

    private float actualAngle = 1;
    private bool closeControl = false;

    public override float TimeInfluence { get { return timeInfluence; }
        set { timeInfluence = value;
            speedOp = speedOpen * timeInfluence;
            speedCl = speedClose * timeInfluence;
        }
    }

    // Use this for initialization
    void Start () {
        Begin();
    }

    public override void Begin()
    {
        base.Begin();
        IsRespawn = false;
        TimeInfluence = TimeInfluence;
    }

    
    void Update()
    {
        PlayAudio();
        Run();
    }

    public void Run()
    {
        //TimeInfluence = Time.timeScale;
        if (IsActivated)
        {
            try
            {
                if (doorRigth == null || doorLeft == null)
                {
                    throw new NullReferenceException();
                }

                if (!closeControl)
                    abrirAlcapao();
                else if (isClose)
                    fecharAlcapao();
            }
            catch (Exception e)
            {
                Debug.LogError("[ERROR]Trapdoor.OpenTrapdoor: " + e.Message);
            }
        }
    }

    private void abrirAlcapao()
    {
        actualAngle += speedOp;

        if (actualAngle <= rotation.z)
        {
            doorRigth.localEulerAngles += Vector3.forward * speedOp;
            doorLeft.localEulerAngles += Vector3.forward * -speedOp;
        }
        else
        {
            actualAngle = rotation.z;
            doorRigth.localEulerAngles = Vector3.forward * actualAngle;
            doorLeft.localEulerAngles = Vector3.forward * -actualAngle;
            closeControl = true;
            desaparecer();
        }
    }

    private void fecharAlcapao()
    {
        actualAngle -= speedCl;
        if (actualAngle >= 0)
        {
            doorRigth.localEulerAngles -= Vector3.forward * speedCl;
            doorLeft.localEulerAngles -= Vector3.forward * -speedCl;
        }
        else 
        {
            actualAngle = 0;
            doorRigth.localEulerAngles -= Vector3.forward * actualAngle;
            doorLeft.localEulerAngles -= Vector3.forward * -actualAngle;
            closeControl = false;
            IsActivated = false;
        }
    }

    private void desaparecer()
    {
        doorRigth.gameObject.SetActive(manterPortas);
        doorLeft.gameObject.SetActive(manterPortas);
    }

}
