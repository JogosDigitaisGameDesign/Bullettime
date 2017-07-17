using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    [SerializeField] private float damage = 5;
    [SerializeField] private float lengthLimit = 1.5f;
    [SerializeField] private float lengthIncrease = 0.1f;
    private Vector3 lengthInc;
    private Vector3 lengthLim;
    
	// Use this for initialization
	void Start () {
        lengthInc = new Vector3(lengthIncrease, lengthIncrease, lengthIncrease);
        lengthLim = transform.localScale + (new Vector3(lengthLimit, lengthLimit, lengthLimit));
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale += lengthInc;
        if (transform.localScale.y >= lengthLim.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision other) {
        string auxTag = other.gameObject.tag;
        if (auxTag == "Enemy")
        {
            //Personagem inimigo = outro.gameObject.GetComponent<Personagem>();
            //inimigo.decrementarHP(dano);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        string auxTag = other.gameObject.tag;
        if (auxTag == "Enemy")
        {
            //Personagem inimigo = outro.gameObject.GetComponent<Personagem>();
            //inimigo.decrementarHP(dano * 0.25f);
        }
    }

}
