using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class CreateController : MonoBehaviour
{
    public BulletController bulletPrefab;
    public ExplosionController explosionPrefab;
    public EnemyController enemyPrefab;
    public int enemySpawned = 0;
    public int waveLevel = 1;

    [SerializeField]
    int delayCounter;

    public BulletController CreateBullet(Transform tranShoot)
    {
        return Instantiate(bulletPrefab, tranShoot.position, tranShoot.rotation);
    }

    public ExplosionController CreateExplosion(Transform transform)
    {
        return Instantiate(explosionPrefab, transform.position, transform.rotation);
    }

    void FixedUpdate()
    {
    }

}

public class Creater : SingletonMonoBehaviour<CreateController>
{

}
