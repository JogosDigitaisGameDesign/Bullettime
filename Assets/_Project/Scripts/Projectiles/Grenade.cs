using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour
{

    [SerializeField] private Explosion explosionPrefab;
    [SerializeField] private float timerDestroy = 5;
    [SerializeField] private float damage = 5;
    private float timer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDestroy)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        string auxTag = other.gameObject.tag;
        if (auxTag == "Enemy")
        {
            //Personagem inimigo = outro.gameObject.GetComponent<Personagem>();
            //inimigo.decrementarHP(dano);
            Explode(other);
        }
        else if (auxTag != "Weapon")
        {
            Explode(other);
        }

    }

    private void Explode(Collision other)
    {
        // Causar explosão
        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
    }
}
