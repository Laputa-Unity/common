using System.Collections;
using UnityEngine;

public class PunchEffect : GoEffect
{
    public float punchScale = 1.2f; // the scale to punch the character by
    private bool isPunching = false; // flag to determine if the character is currently punching

    void Update()
    {
        // check if the character is not currently punching and the user presses the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // start the punch animation
            StartCoroutine(DoEffect());
        }
    }
    
    protected override IEnumerator DoEffect()
    {
        // set the flag to indicate that the character is currently punching
        isPunching = true;

        float startTime = Time.time;
        float endTime = startTime + time;
        float currentTime = startTime;

        while (currentTime < endTime)
        {
            float progress = (currentTime - startTime) / time;
            float curveScale = curve.Evaluate(progress);

            Vector3 newScale = OriginalScale;
            if (!lockXAxis) newScale.x *= (1 + (punchScale - 1) * curveScale);
            if (!lockYAxis) newScale.y *= (1 + (punchScale - 1) * curveScale);
            if (!lockZAxis) newScale.z *= (1 + (punchScale - 1) * curveScale);

            transform.localScale = newScale;
            currentTime += Time.deltaTime;
            yield return null;
        }

        // set the character back to its original scale
        transform.localScale = OriginalScale;

        // set the flag to indicate that the character is no longer punching
        isPunching = false;
        base.DoEffect();
    }
}
