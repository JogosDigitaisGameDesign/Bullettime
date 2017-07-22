using UnityEngine;
using System.Collections;

public class TrapdoorTest : MonoBehaviour {
    [Header("State")]
    [SerializeField] private Trapdoor trapDoor = null;
    [SerializeField] private bool isActivatedTest = false;

    [Header("Time Influence")]
    [SerializeField] [Range(0, 2)] private float timeInfluence = 1;
    [SerializeField] private bool isTimeInfluenceTest = false;
    [SerializeField] private bool isTimeScale = false;
    [SerializeField] private float timeScale = 1;


    // Use this for initialization
    void Start () {
        trapDoor = GetComponent<Trapdoor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isActivatedTest)
        {
            isActivatedTest = false;
            trapDoor.IsActivated = true;
        }
        if (isTimeInfluenceTest)
        {
            isTimeInfluenceTest = false;
            trapDoor.TimeInfluence = timeInfluence;
        }

        if (isTimeScale)
        {
            isTimeScale = false;
            //Time.timeScale = timeScale;
            //trapDoor.TimeInfluence = Time.timeScale;
        }
    }
}
