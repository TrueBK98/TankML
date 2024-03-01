using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetInfront : MonoBehaviour, ICheckTarget
{
    public bool CheckTarget(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angle = Vector3.Angle(Player.Instance.body.up, directionToTarget);

        if (Mathf.Abs(angle) < 90) return true;
        return false;
    }
}
