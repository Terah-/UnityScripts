/*
 *  Terah
 *  https://github.com/Terah-
 *
 *  Flicker :
 *  Simulate a flickering effet
 *
 *  Params :
 *  Smoothness - controls how smooth are the changes (default 20)
 *  Frequency - controls how often changes occur (default 10)
 *
 *  Use GetValue() to get a value bewteen 0 and 1
 *  Use GetValue(min, max) to get a value between min and max
 *
 */

using UnityEngine;

public class Flicker
{

    private int smoothness;
    public float frequency;
    private float[] values;

    private float currentValue;
    private float nextValue;

    private float time;

    public Flicker()
    {
        Smoothness = 20;
        Frequency = 5f;
    }

    public Flicker(int smoothness, float frequency)
    {
        Smoothness = smoothness;
        Frequency = frequency;
    }

    public int Smoothness
    {
        get
        {
            return smoothness;
        }

        set
        {
            smoothness = value;
            if (smoothness < 1)
                smoothness = 1;
            values = new float[smoothness+1];
            for (int i = 0; i < smoothness+1; ++i)
                values[i] = Random.value;
        }
    }

    public float Frequency
    {
        get
        {
            return frequency;
        }

        set { frequency = value > 0 ? value : 1f; }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= (1f/Frequency))
        {

            time -= (1f/Frequency);

            currentValue = nextValue;
            nextValue = 0;

            for (int i = 0; i < smoothness; ++i)
            {
                values[i] = values[i + 1];
                nextValue += values[i];
            }
            nextValue /= smoothness;

            values[smoothness] = Random.value;
        }
    }

    public float GetValue()
    {
        Update();

        return Mathf.Lerp(currentValue, nextValue, time / (1/Frequency));
    }

    public float GetValue(float min, float max)
    {
        return Mathf.Lerp(min, max, GetValue());
    }

}
