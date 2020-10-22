using UnityEngine;

public class ChangePosition : Action
{
    public Vector2 newPosition;
    [Min(0.001f)]
    public float speed = 0;
    public bool relative;
    public bool waitUntilEnd;

    private Vector2 startPosition, targetPosition;
    private float timer;
    private bool isMoving;

    public override void DoAction()
    {
        if (waitUntilEnd) 
            isActing = true;

        startPosition = transform.position;
        targetPosition = newPosition;
        if (relative) 
            targetPosition += startPosition;

        timer = 0;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            timer += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(startPosition, targetPosition, timer);
            if(timer >= 1)
            {
                transform.position = targetPosition;
                isActing = false;
                isMoving = false;
            }
        }
    }
}

