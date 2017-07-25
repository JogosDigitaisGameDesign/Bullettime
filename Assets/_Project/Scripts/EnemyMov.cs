using UnityEngine;
using System.Collections;

public class EnemyMov : MonoBehaviour
{

    public Transform player;
    public float MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= MinDist)
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            MoveSpeed = 4;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
            Destroy(gameObject);
    }

}
