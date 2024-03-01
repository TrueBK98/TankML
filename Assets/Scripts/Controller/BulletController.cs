using System.Collections;
using System.Collections.Generic;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine;

public interface IHit
{
    void OnHit(float damage);
}

public class BulletController : MonoBehaviour
{
    int count;
    public float damage;
    public TankAgent agent;

    public void EndBullet()
    {
        Creater.Instance.CreateExplosion(transform);
        GameObject.Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(count > 240)
        {
            EndBullet();
            count = 0;
        }
        count++;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.2f);
        if(hit.transform != null)
        {
            IHit iHit = hit.transform.GetComponentInParent<IHit>();
            if(iHit != null)
            {
                iHit.OnHit(damage);
                agent.AddReward(0.1f);
                EndBullet();
                return;
            }
        }
    }
}
