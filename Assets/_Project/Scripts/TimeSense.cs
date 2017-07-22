using UnityEngine;
using System.Collections;

public class TimeSense : MonoBehaviour {

    [SerializeField] private float timeScale = 1;

    [SerializeField] [Range(0.01f, 0.9f)] private float incTime = 0.01f;
    [SerializeField] [Range(0.01f, 0.9f)] private float minTime = 0.1f;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    private void OnTriggerEnter(Collider other)
    {
        checkTrap(other, timeScale);

        TimeBehaviour tb = other.gameObject.GetComponent<TimeBehaviour>();
        if (tb != null)
            tb.localTimeScale = timeScale;
    }

    private void OnTriggerExit(Collider other)
    {
        checkTrap(other, 1);

        TimeBehaviour tb = other.gameObject.GetComponent<TimeBehaviour>();
        if (tb != null)
            tb.localTimeScale = 1;
    }

    private void checkTrap(Collider other, float time)
    {
        if (other.tag == "Trap")
        {
            Debug.Log(other.tag + "");
            other.GetComponent<Door>().TimeInfluence = time;
        }
    }
}
