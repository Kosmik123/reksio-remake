using UnityEngine;

public class PlaySound : Action
{
    public new AudioClip audio;
    public bool waitUntilEnd;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = StateOfGame.main.GetComponent<AudioSource>();
    }
    public override void DoAction()
    {
        if (waitUntilEnd)
            isActing = true;

        AudioSource audioSource = StateOfGame.main.GetComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.Play();
    }

    private void Update()
    {
        if (isActing && !audioSource.isPlaying)
            isActing = false;
    }
}




