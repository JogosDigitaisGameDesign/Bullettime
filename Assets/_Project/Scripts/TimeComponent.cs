using UnityEngine;
using System.Collections;

public class TimeComponent : MonoBehaviour {

    private float timeInfluence = 1;
    private TimeSense timeSense = null;

    public virtual float TimeInfluence { get { return timeInfluence; } set { timeInfluence = value; } }
    public TimeSense TimeSense { get { return timeSense; } set { timeSense = value; } }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
        Release();
    }


    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bubble")
            TimeInfluence = 1;
    }

    protected void Release()
    {
        if (timeSense != null)
        {
            if (!timeSense.gameObject.active)
            {
                TimeInfluence = 1;
                timeSense = null;
            }
        }
    }

}
