using System.Collections;
using UnityEngine;

public abstract class GoEffect : MonoBehaviour
{
    public float time = 0.2f; // the duration of the punch animation
    public AnimationCurve curve; // the animation curve to control the scaling over time
    public bool lockXAxis = false; // flag to lock the X axis of the punch animation
    public bool lockYAxis = false; // flag to lock the Y axis of the punch animation
    public bool lockZAxis = false; // flag to lock the Z axis of the punch animation

    protected Vector3 OriginalScale; // the original scale of the character

    // Start is called before the first frame update
    void Start()
    {
        // store the original scale of the character
        OriginalScale = transform.localScale;
    }

    protected virtual IEnumerator DoEffect()
    {
        yield return null;
    }
}
