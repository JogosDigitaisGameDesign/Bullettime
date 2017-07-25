using UnityEngine;
using System.Collections;

public class EnemyMov : TimeComponent
{

    public Transform player;
    public float MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    private float moveSpeed = 0;

    public override float TimeInfluence { get { return moveSpeed; }
        set {
            if (value == 1)
                moveSpeed = MoveSpeed;
            else
                moveSpeed = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        moveSpeed = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= MinDist)
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            moveSpeed = 4;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
            Destroy(gameObject);
    }

}
