using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    [SerializeField] private Trapdoor trapDoor;

    public float TimeInfluence { set { trapDoor.TimeInfluence = value; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
