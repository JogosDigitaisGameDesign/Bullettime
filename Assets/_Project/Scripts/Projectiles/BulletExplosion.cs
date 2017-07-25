using UnityEngine;
using System.Collections;

public class BulletExplosion : ITrap
{
    private SphereCollider sphereColl;
    private Rigidbody      rbody;

    [SerializeField]
    private float damage = 5;
    [Header("Scale:")]
    [SerializeField]
    private float lengthLimit = 1.5f;
    [SerializeField]
    private float lengthIncrease = 0.1f;
    private Vector3 lengthInc;
    private Vector3 lengthLim;
    private bool isExplosion = false;

    [Header("Timer:")]
    [SerializeField]
    private float timerDestroyLimit = 5;
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
        sphereColl = GetComponent<SphereCollider>();
        rbody = GetComponent<Rigidbody>();
        lengthInc = new Vector3(lengthIncrease, lengthIncrease, lengthIncrease);
        lengthLim = transform.localScale + (new Vector3(lengthLimit, lengthLimit, lengthLimit));
    }

    // Update is called once per frame
    void Update()
    {

        if (isExplosion)
        {
            transform.localScale += lengthInc;
            if (transform.localScale.y >= lengthLim.y)
                isExplosion = false;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > timerDestroyLimit)
            {
                TimeSense tsense = GetComponent<TimeSense>();
                if (tsense != null)
                    tsense.Release();
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isExplosion)
        {
            isExplosion = true;
            sphereColl.isTrigger = true;
            rbody.useGravity = false;
            rbody.velocity = Vector2.zero;
        }
    }

}
