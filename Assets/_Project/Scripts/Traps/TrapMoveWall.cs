using UnityEngine;
using System.Collections;
using System;

public class TrapMoveWall : ITrap
{
    [SerializeField]
    private Transform wall;
    [SerializeField]
    private Transform target;
    private Vector3 pointA;

    [SerializeField]
    private float damage = 1;
    [SerializeField]
    private bool autoReturn = true;
    private bool isMove = true;

    [SerializeField]
    private float speedGo = 10f;
    [SerializeField]
    private float speedReturn = 5f;
    private float speed = 0;
    [SerializeField] private float distanceLimit = 0.1f;

    private Vector3 forward = Vector3.zero;

    void Awake()
    {
        
    }



    // Use this for initialization
    void Start()
    {
        pointA = wall.position;
        speed = speedGo;
    }

    // Update is called once per frame
    void Update()
    {
        // Audio
        //executarAudio();
        //Run();
        if (IsActivated)
        {
            if (speed == speedGo)
            {
                float distance = Vector3.Distance(wall.position, target.position);
                if (distance > distanceLimit)
                    wall.position = Vector3.Lerp(wall.position, target.position, (speed * TimeInfluence) * Time.deltaTime);
                else
                    speed = speedReturn;
            }
            else
            {
                if (autoReturn)
                {
                    float distance = Vector3.Distance(wall.position, pointA);
                    if (distance > distanceLimit)
                        wall.position = Vector3.Lerp(wall.position, pointA, (speed * TimeInfluence) * Time.deltaTime);
                    else
                    {
                        speed = speedGo;
                        IsActivated = false;
                    }
                }
                else
                    IsActivated = false;
            }
        }
    }
}
