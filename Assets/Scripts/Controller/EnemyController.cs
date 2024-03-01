using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class EnemyController : TankController
{
    int count1;
    int count2;
    int endCount;
    
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        levelController.Level = Creater.Instance.waveLevel;
        tranShoot.up *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12f, 12f), Mathf.Clamp(transform.position.y, -12f, 12f));
        /*count1++;
        Vector3 playerPos = Player.Instance.transform.position;

        Vector3 gunDirection = tranShoot.position - playerPos;
        Vector3 bodyDirection = playerPos - body.position;
        RotateGun(gunDirection);


        if (count1 >= 240)
        {
            System.Random rand = new System.Random();
            double min = -180;
            double max = 180;
            double range = max - min;
            float randX = 0;
            float randY = 0;

            if (count1 == 240)
            {
                while (randX == 0)
                {
                    randX = (float)(rand.NextDouble() * range + min);
                }

                while (randY == 0)
                {
                    randY = (float)(rand.NextDouble() * range + min);
                }
            }

            Move((body.up + new Vector3(randX, randY)).normalized);

            if (count1 >= 360)
            {
                count1 = 0;
            }
        }
        else
        {
            Move(bodyDirection.normalized);
        }

        if (count2 > 180)
        {
            Shoot();
            count2 = 0;
        }
        else
        {
            count2++;
        }*/
    }

    void FixedUpdate()
    {
        endCount++;

        if (endCount >= 790)
        {
            //OnDie();
        }
    }

    protected override void OnDie()
    {
        Creater.Instance.enemySpawned--;
        Destroy(gameObject);
    }

    protected override TankInfo GetTankInfo(int level)
    {
        return DataManager.Instance.enemyVO.GetTankInfo(level);
    }
}
