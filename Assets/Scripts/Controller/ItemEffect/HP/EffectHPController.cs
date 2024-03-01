using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHPInfo
{
    public int hp;
}

public class EffectHPController : MonoBehaviour,ItemEffect
{
    public EffectHPInfo info;

    public object Info { set => info = (EffectHPInfo)value; }

    public void Active()
    {
        HpController hPController = GetComponentInChildren<HpController>();
        hPController.CurrentValue -= info.hp;
        Destroy(this);
    }
}
