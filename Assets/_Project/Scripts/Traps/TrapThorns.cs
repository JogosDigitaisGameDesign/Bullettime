using UnityEngine;
using System.Collections;
using System;

public class TrapThorns : ITrap {

    [SerializeField] private Transform maxPoint;
    [SerializeField] private float speed = 5;
    //private Transform pontoInicial;
    //private bool retorna = false;

    // Use this for initialization
    void Start () {
        Begin();
	}
	
	// Update is called once per frame
	void Update () {
        PlayAudio();
        Run();
    }

    public override void Begin()
    {
        base.Begin();
        IsRespawn = false;
        //pontoInicial = transform;
    }

    private void Run()
    {
        if (IsActivated)
        {
            transform.position = Vector3.Lerp(transform.position, maxPoint.position, speed * Time.deltaTime);
        }
    }

    

}
