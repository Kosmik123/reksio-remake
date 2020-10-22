using UnityEngine;

public class ChangeRotation : Action
{
    public float newAngle;
    [Min(0.001f)]
    public float speed = 0;
    public bool relative, waitUntilEnd;

    private float startAngle, targetAngle;
    private float timer;
    private bool isRotating;

    public override void DoAction()
    {
        if(waitUntilEnd)
            isActing = true;

        startAngle = transform.rotation.eulerAngles.z;
        targetAngle = newAngle;
        if (relative)
            targetAngle += startAngle;

        timer = 0;
        isRotating = true;
    }

    private void Update()
    {
        if (isRotating)
        {
            timer += Time.deltaTime * speed;
            float angle = Mathf.Lerp(startAngle, targetAngle, timer);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (timer >= 1)
            {
                transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
                isRotating = false;
                isActing = false;
            }
        }
    }
}


