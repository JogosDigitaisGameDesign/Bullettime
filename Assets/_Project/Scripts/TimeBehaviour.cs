using UnityEngine;

public class TimeBehaviour : TimeComponent
{
    private Rigidbody r = null;
    private float _localTimeScale = 1.0f;

    void Start() {
        
    }

    
    public override float TimeInfluence
    {
        get
        {
            return _localTimeScale;
        }
        set
        {
            if (r == null) r = GetComponent<Rigidbody>();
            if (r != null)
            {
                float multiplier = value / _localTimeScale;
                r.angularDrag *= multiplier;
                r.drag *= multiplier;
                r.mass /= multiplier;
                r.velocity *= multiplier;
                r.angularVelocity *= multiplier;
            }

            _localTimeScale = value;
        }
    }


    //public float localDeltaTime
    //{
    //    get
    //    {
    //        return Time.deltaTime * Time.timeScale * _localTimeScale;
    //    }
    //}

   void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        // Counter gravity
        //if (r == null)
        //    r = GetComponent<Rigidbody>();
        //if (r != null)
        //{
        //    r.AddForce(-Physics.gravity + (Physics.gravity * (_localTimeScale * _localTimeScale)), ForceMode.Acceleration);
        //}
    }
}