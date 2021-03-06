﻿using UnityEngine;
using System.Collections;

public class EnemyMov : TimeComponent
{

    public Transform player;
    public float moveSpeed = 4;
    public float MaxDist = 15f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Release();
        if (player != null && Vector3.Distance(transform.position, player.position) < MaxDist)
        {
            transform.LookAt(player);
            transform.position += transform.forward * moveSpeed * TimeInfluence * Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //if(collision.gameObject.tag == "Bubble")
        //    moveSpeed = 4f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
            Destroy(gameObject);
    }

}
