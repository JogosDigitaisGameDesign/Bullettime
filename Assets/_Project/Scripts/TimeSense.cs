using UnityEngine;
using System.Collections;

public class TimeSense : MonoBehaviour {

    [SerializeField] private float timeScale = 1;

    [SerializeField] [Range(0.01f, 0.9f)] private float incTime = 0.01f;
    [SerializeField] [Range(0.01f, 0.9f)] private float minTime = 0.1f;

    float MoveSpeed = 4f;
    bool move = true;
    float timer = 3f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(move)
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (timer < 0)
            Destroy(gameObject);

        timer -= Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {

        checkTrap(other, timeScale);

        checkEnemy(other, timeScale);

        TimeBehaviour tb = other.gameObject.GetComponent<TimeBehaviour>();
        if (tb != null)
            tb.localTimeScale = timeScale;
    }

    private void OnTriggerExit(Collider other)
    {
        checkTrap(other, 1);

        checkEnemy(other, 4);

        TimeBehaviour tb = other.gameObject.GetComponent<TimeBehaviour>();
        if (tb != null)
            tb.localTimeScale = 1;
    }

    private void checkTrap(Collider other, float time)
    {
        if (other.tag == "Trap")
            other.GetComponent<Door>().TimeInfluence = time;
    }

    private void checkEnemy(Collider other, float time)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyMov>().MoveSpeed = time;
            move = false;
        }
            
    }
}
