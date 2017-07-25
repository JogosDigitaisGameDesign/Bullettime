using UnityEngine;
using System.Collections;

public class TimeComponent : MonoBehaviour {

    private float timeInfluence = 1;

    public virtual float TimeInfluence { get { return timeInfluence; } set { timeInfluence = value; } }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
