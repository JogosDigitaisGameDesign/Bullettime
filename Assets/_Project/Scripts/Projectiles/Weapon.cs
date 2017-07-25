using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Rigidbody prjPrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float speed = 200;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void efetuarDisparo()
    {
        GameObject novoProjetil = (GameObject)Instantiate(
            prjPrefab.gameObject,
            launchPoint.position,
            launchPoint.rotation
            );

        Rigidbody rbody = novoProjetil.GetComponent<Rigidbody>();
        rbody.AddForce(launchPoint.forward * speed, ForceMode.Impulse);
    }
}
