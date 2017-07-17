using UnityEngine;
using System.Collections;

public class TrapRespawn : MonoBehaviour {

    [SerializeField] private ITrap trapPrefab;
    [SerializeField] private bool frequencyZAxis = true;
    [SerializeField] private Vector3 direction = Vector3.forward;
    private Quaternion rotation;

    [SerializeField] private float timerRespawnLimit = 0.5f;
    private float timerRespawn = 0;
    private bool isActivated = false;
    private PlayerControl player = null;

    public bool IsActivated { get { return isActivated; } set { isActivated = value; } }

    public ITrap TrapPrefab { get { return trapPrefab; } set { trapPrefab = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; } }
    public PlayerControl Player { get { return player; } set { player = value; } }

    // Use this for initialization
    void Start () {
        if(frequencyZAxis)
        {
            direction = transform.forward; // new Vector3(0,0,);
            rotation = transform.rotation;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isActivated)
        {
            timerRespawn += Time.deltaTime;
            if (timerRespawn >= timerRespawnLimit)
            {
                timerRespawn = 0;
                // Lançar flechas
                GameObject gameObj = (GameObject) Instantiate(
                    trapPrefab.gameObject,
                    transform.position,
                    Quaternion.identity
                );

                ITrap trap =  gameObj.GetComponent<ITrap>();
                trap.Begin();
                trap.IsActivated = true;
                trap.Player = player;
                trap.Direction = direction;
                if (frequencyZAxis)
                    trap.transform.rotation = rotation;

                if (!trap.IsRespawn)
                    isActivated = false;
            }
        }	
	}

    private void OnTriggerEnter(Collider outro)
    {
        if(outro.gameObject.tag == "Player")
            isActivated = true;
    }
}
