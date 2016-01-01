/*
 * Terah
 * https://github.com/Terah-
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
