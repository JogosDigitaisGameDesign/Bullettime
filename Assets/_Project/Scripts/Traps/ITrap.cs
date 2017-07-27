using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public abstract class ITrap : TimeComponent {

    [SerializeField] private AudioClip soundFX;
    private AudioSource audioSource;

    private bool isAudioExecute = false;

    private Vector3 direction = Vector3.zero;
    private bool isRespawn = false;
    private bool isActivated = false;
    private PlayerControl player = null;

    public Vector3 Direction { get { return direction; } set { direction = value; } }
    public bool IsRespawn { get { return isRespawn; } set { isRespawn = value; } }
    public bool IsActivated { get { return isActivated; } set { isActivated = value; } }
    public PlayerControl Player { get { return player; } set { player = value; } }


    public virtual void Begin()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        base.Update();
    }

    public void PlayAudio()
    {
        if (IsActivated)
        {
            // Audio
            if (soundFX != null && !isAudioExecute)
            {
                isAudioExecute = true;
                audioSource.clip = soundFX;
                audioSource.Play();
            }
        }
    }
}
