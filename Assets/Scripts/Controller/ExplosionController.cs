using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public void EndExplosion()
    {
        Destroy(gameObject);
    }
}
