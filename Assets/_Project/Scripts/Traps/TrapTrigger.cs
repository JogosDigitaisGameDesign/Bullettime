using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TrapTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundTrigger;
    [SerializeField]
    private bool isActivated = true;
    [SerializeField]
    private ITrap[] traps;
    [SerializeField]
    private TrapRespawn[] respawnPoints;

    private Renderer rend = null;

    private AudioSource audioSource = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            rend.enabled = !rend.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Audio
            if (audioSource != null)
            {
                if (soundTrigger != null && !audioSource.isPlaying /*!audioDisparado*/)
                {
                    audioSource.clip = soundTrigger;
                    audioSource.Play();
                }
            }

            if (respawnPoints.Length != 0)
            {
                for (int i = 0; i < respawnPoints.Length; i++)
                {
                    respawnPoints[i].IsActivated = isActivated;
                    respawnPoints[i].Player = other.gameObject.GetComponent<PlayerControl>();
                }
            }
            if (traps.Length != 0)
            {
                for (int i = 0; i < traps.Length; i++)
                {
                    traps[i].IsActivated = isActivated;
                    traps[i].Player = other.gameObject.GetComponent<PlayerControl>();
                }
            }
        }
    }
}
