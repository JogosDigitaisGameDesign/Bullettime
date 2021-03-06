﻿using UnityEngine;
using System.Collections.Generic;

public class TimeSense : MonoBehaviour {

    [SerializeField] private string[] tags = { "Trap", "Enemy", "Arrow" };
    [SerializeField] private float timeScale = 1;

    [SerializeField] [Range(0.01f, 0.9f)] private float incTime = 0.01f;
    [SerializeField] [Range(0.01f, 0.9f)] private float minTime = 0.1f;

    float MoveSpeed = 4f;
    //bool move = true;

    //private List<TimeComponent> listTimeComponents = new List<TimeComponent>();

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        

        

        //if(move)
        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //if (timer < 0)
        //    Destroy(gameObject);

        //timer -= Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (TimeInfluenceActivated(other, timeScale))
        {
            other.GetComponent<TimeComponent>().TimeSense = this;
        }
        //checkArrow(other, timeScale);
        //checkTrap(other, timeScale);
        //checkEnemy(other, 1.5f);

        //TimeBehaviour tb = other.gameObject.GetComponent<TimeBehaviour>();
        //if (tb != null)
        //    tb.TimeInfluence = timeScale;
    }

    private void OnTriggerExit(Collider other)
    {

        TimeInfluenceActivated(other, 1);
        //checkArrow(other, 1);
        //checkTrap(other, 1);
        //checkEnemy(other, 4f);

        //TimeBehaviour tb = other.gameObject.GetComponent<TimeBehaviour>();
        //if (tb != null)
        //    tb.TimeInfluence = 1;
    }

    private bool TimeInfluenceActivated(Collider other, float time)
    {
        bool ok = false;
        //if(other.tag != "Enemy")
        for (int i = 0; i < tags.Length; i++)
        {
            string auxTag = tags[i];

            if (other.tag == auxTag)
            {
                TimeComponent timeComponent = other.GetComponent<TimeComponent>();

                //bool foundID = searchID(timeComponent);
                //if (!foundID)
                //{
                    if(timeComponent != null)
                        timeComponent.TimeInfluence = time;
                    // listTimeComponents.Add(timeComponent); //other.transform.GetInstanceID());
                //}
                ok = true;
                break;
            }
        }
        return ok;
    }

    protected bool searchID(TimeComponent other)
    {
        bool found = false;

        // Verificar se está na lista
        //found = false; // se for listOpponents.Count == 0, adiciona
        //if (listTimeComponents.Count != 0)
        //{
        //    foreach (TimeComponent oth in listTimeComponents)
        //    {
        //        if (oth != null)
        //        {
        //            if (other.transform.GetInstanceID() == oth.transform.GetInstanceID())
        //            {
        //                found = true;
        //                break;
        //            }
        //        }
        //    }
        //}
        return found;
    }

    public void Release()
    {

        //foreach (TimeComponent tComp in listTimeComponents)
        //{
        //    tComp.TimeInfluence = 1;
        //}

    }

    //private void checkTrap(Collider other, float time)
    //{
    //    if (other.tag == "Trap")
    //        other.GetComponent<Door>().TimeInfluence = time;
    //}

    //private void checkEnemy(Collider other, float time)
    //{
    //    if (other.tag == "Enemy")
    //        other.GetComponent<EnemyMov>().moveSpeed = time;
    //}

        //private void checkArrow(Collider other, float time)
        //{
        //    if (other.tag == "Arrow")
        //    {
        //        other.GetComponent<TimeBehaviour>().TimeInfluence= time;
        //        move = false;
        //    }

        //}
    }
