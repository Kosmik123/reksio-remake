using UnityEngine;

public class Wait : Action
{
    public float time;

    private float timer;

    public override void DoAction()
    {
        isActing = true;
        timer = 0;
    }

    private void Update()
    {
        if (isActing)
        {
            timer += Time.deltaTime;
            if(timer >= time)
            {
                isActing = false;
            }
        }
    }
}
