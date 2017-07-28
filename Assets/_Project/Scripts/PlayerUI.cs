using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image cooldown;



    public float Lifebar { set { lifeBar.fillAmount = value; } }
    public float Cooldown { set { cooldown.fillAmount = value; } }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
