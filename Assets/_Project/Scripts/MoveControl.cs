using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {

    [SerializeField] private float speedWalk = 10;
    [SerializeField] private float speedRun = 20;
    private float speed = 0;



    public float SpeedWalk { get { return speedWalk; } }
    public float SpeedRun  { get { return speedRun; } }
    public float Speed { get { return speed; } set { speed = value; } }

    public void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {

        Speed = speedWalk;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Stop()
    {
        
    }

    public void Move()
    {
        
    }
}
