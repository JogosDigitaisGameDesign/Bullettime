using UnityEngine;
using System.Collections;

public class Door : TimeComponent
{
    [SerializeField]
    private ITrap trapDoor;

    public override float TimeInfluence { get { return trapDoor.TimeInfluence; } set { trapDoor.TimeInfluence = value; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

}
