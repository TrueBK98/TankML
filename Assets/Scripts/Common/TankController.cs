using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankInfo
{
    public int damage;
    public int hp;
}

public abstract class TankController : MoveController, IHit
{
    //public TankInfo[] tankInfos;
    public TankAgent agent;
    public Transform gun;
    public Transform tranShoot;
    public Transform body;
    public HpController hpController;
    public LevelController levelController;
    public float damage;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        hpController.onDie = OnDie;
        levelController.onLevelUp = OnLevelUp;
        agent = GetComponent<TankAgent>();
    }

    // Update is called once per frame
    public override void Move(Vector3 direction)
    {
        body.up = direction;
        base.Move(direction);
    }

    public void RotateGun(Vector3 direction)
    {
        gun.up = direction;
    }

    public void Shoot()
    {
        BulletController bullet = Creater.Instance.CreateBullet(tranShoot);
        bullet.agent = agent;
        bullet.damage = damage;
    }

    protected abstract void OnDie();

    public void OnHit(float damage)
    {
        hpController.TakeDamage(damage);
    }

    void OnLevelUp(int level)
    {
        TankInfo tankInfo = GetTankInfo(level);
        damage = tankInfo.damage;
        hpController.HP = tankInfo.hp;
    }

    protected abstract TankInfo GetTankInfo(int level);
}
