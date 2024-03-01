using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : TankController
{
    // Start is called before the first frame update
    int counter;

    public JoyStickController rightJoystick;
    public JoyStickController leftJoystick;

    protected override void OnDie()
    {
        Debug.Log("OnDie");
    }

    protected override void Awake()
    {
        base.Awake();
        leftJoystick.onUp = OnUp;
        tranShoot.up *= -1;
    }

    void Start()
    {
        levelController.CurrentValue = 0;
        levelController.Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 direction = new Vector3(rightJoystick.Direction.x, rightJoystick.Direction.y);
        if (direction.x != 0 && direction.y != 0)
        {
            Move(direction);
        }*/

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (xInput != 0 || yInput != 0)
        {
            Move(new Vector3(xInput, yInput));
        }

        Vector3 gunDirection;
        gunDirection = body.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gunDirection.z = transform.position.z;
        RotateGun(gunDirection);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        /*if (leftJoystick.Direction != Vector3.zero)
        {
            Vector3 gunDirection = leftJoystick.Direction * -1;
            gunDirection.z = 0;
            RotateGun(gunDirection);
        }*/


    }

    void OnEnemyDie(object data)
    {
        EnemyController enemy = (EnemyController)data;
        levelController.CurrentValue = levelController.CurrentValue + enemy.levelController.Level * 50;
    }

    protected override TankInfo GetTankInfo(int level)
    {
        return DataManager.Instance.playerVO.GetTankInfo(level);
    }

    protected void OnUp()
    {
        //Shoot();
    }
}
public class Player : SingletonMonoBehaviour<PlayerController>
{

}

