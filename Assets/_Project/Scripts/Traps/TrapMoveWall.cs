using UnityEngine;
using System.Collections;
using System;

public class TrapMoveWall : ITrap
{
    [SerializeField]
    private Transform wall;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private Transform returnPoint;
    //private Vector3 pointA;

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
        speed = speedGo;
    }



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Audio
        //executarAudio();
        //Run();
        try {
            if (IsActivated)
            {
                if (speed == speedGo)
                {
                    float distance = Vector3.Distance(wall.localPosition, targetPoint.localPosition);
                    if (distance > distanceLimit)
                        wall.localPosition = Vector3.Lerp(wall.localPosition, targetPoint.localPosition, (speed * TimeInfluence) * Time.deltaTime);
                    else
                    {
                        wall.localPosition = targetPoint.localPosition;
                        speed = speedReturn;
                    }
                }
                else
                {
                    if (autoReturn)
                    {
                        float distance = Vector3.Distance(wall.localPosition, returnPoint.localPosition);
                        if (distance > distanceLimit)
                            wall.localPosition = Vector3.Lerp(wall.localPosition, returnPoint.localPosition, (speed * TimeInfluence) * Time.deltaTime);
                        else
                        {
                            wall.localPosition = returnPoint.localPosition;
                            speed = speedGo;
                            IsActivated = false;
                        }
                    }
                    else
                        IsActivated = false;
                }
            }
        }
        catch(Exception e)
        {
            Debug.Log("Error: " + e.Message + "\n \n " + e.StackTrace + "\n \n " + e.InnerException);
        }
    }
}
