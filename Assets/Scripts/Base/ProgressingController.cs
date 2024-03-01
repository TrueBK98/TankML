using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgressingController : MonoBehaviour
{
    public float currentValue;
    public float maxValue;
    Vector3 originalScale;

    public float CurrentValue
    {
        set
        {
            currentValue = value;
            if (currentValue > maxValue) currentValue = maxValue;
            if (currentValue < 0) currentValue = 0;
            DisplayValue();
            OnChangeCurrentValue(currentValue);
        }
        get
        {
            return currentValue;
        }
    }

    protected abstract void OnChangeCurrentValue(float value);

    protected virtual void DisplayValue()
    {
        if (originalScale.x <= 0) originalScale = transform.localScale;
        transform.localScale = new Vector3((float)(currentValue / maxValue) * originalScale.x, originalScale.y, originalScale.z);
    }
}
