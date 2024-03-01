using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HpController : ProgressingController
{
    public Action onDie;

    public float HP
    {
        set
        {
            maxValue = value;
            CurrentValue = maxValue;
        }
        get
        {
            return currentValue;
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentValue -= damage;
    }

    protected override void OnChangeCurrentValue(float value)
    {
        if(value == 0)
        {
            if(onDie != null)
            {
                onDie();
            }
        }
    }
}
