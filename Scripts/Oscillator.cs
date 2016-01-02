/*
 *  Terah
 *  https://github.com/Terah-
 *
 *  Oscillator :
 *  Returns an oscillating value
 *
 *  Params :
 *  Frequency - controls the frequency of the oscillation (default 1)
 *
 *  Use GetValue() to get a value bewteen 0 and 1
 *  Use GetValue(min, max) to get a value between min and max
 *
 */

using UnityEngine;

public class Oscillator
{
    private float time = 0f;

    // In oscillations per second
    public float Frequency;

    public Oscillator()
    {
        Frequency = 1f;
    }

    public Oscillator(float frequency)
    {
        Frequency = frequency;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public float GetValue()
    {
        Update();
        return (Mathf.Cos(time*Frequency*Mathf.PI*2) + 1f)/2f;
    }

    public float GetValue(float min, float max)
    {
        return Mathf.Lerp(min, max, GetValue());
    }
}
