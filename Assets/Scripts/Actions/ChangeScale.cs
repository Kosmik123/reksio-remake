using UnityEngine;

public class ChangeScale : Action
{
    public Vector2 newScale;
    [Min(0.001f)]
    public float speed = 0;
    public bool relative;
    public bool waitUntilEnd;

    private Vector2 startScale, targetScale;
    private float timer;
    private bool isScaling;

    public override void DoAction()
    {
        if (waitUntilEnd)
            isActing = true;

        startScale = transform.localScale;
        targetScale = newScale;
        if (relative)
            targetScale *= startScale;

        timer = 0;
        isScaling = true;
    }

    private void Update()
    {
        if (isScaling)
        {
            timer += Time.deltaTime * speed;
            transform.localScale = Vector2.Lerp(startScale, targetScale, timer);
            if (timer >= 1)
            {
                transform.localScale = targetScale;
                isActing = false;
                isScaling = false;
            }
        }
    }
}

