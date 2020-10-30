using UnityEngine;

public class PlaySound : Action
{
    public new AudioClip audio;
    public bool waitUntilEnd;

    public override void DoAction()
    {
        if (waitUntilEnd)
            isActing = true;

        GameController.main.audioSource.clip = audio;
        GameController.main.audioSource.Play();
    }

    private void Update()
    {
        if (isActing && !GameController.main.audioSource.isPlaying)
            isActing = false;
    }
}




