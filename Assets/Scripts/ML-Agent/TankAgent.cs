using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TankAgent : Agent
{
    TankController tankController;
    float tankLastCurrentHP;

    int count;

    public override void Initialize()
    {
        tankController = GetComponent<TankController>();
        tankLastCurrentHP = tankController.hpController.currentValue;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(tankController.hpController.currentValue);
        sensor.AddObservation(transform.position);
        sensor.AddObservation(tankController.gun.up);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actionX = Mathf.Clamp(actionBuffers.ContinuousActions[0], -1f, 1f);
        var actionY = Mathf.Clamp(actionBuffers.ContinuousActions[1], -1f, 1f);
        tankController.Move(new Vector3(actionX, actionY));

        /*var PointX = actionBuffers.ContinuousActions[2];
        var PointY = actionBuffers.ContinuousActions[3];
        Vector3 gunDirection;
        gunDirection = tankController.body.position - new Vector3(PointX * 100, PointY * 100);

        gunDirection.z = transform.position.z;
        tankController.RotateGun(gunDirection);*/
        

        if (count > 20)
        {
            tankController.Shoot();
            count = 0;
        }
        else
        {
            count++;
        }

        if (tankController.hpController.currentValue <= 0)
        {
            AddReward(-1f);
            EndEpisode();
        }
    }
    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        tankController.hpController.HP = tankController.hpController.maxValue;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
        continuousActionsOut[2] = Input.GetAxis("Horizontal");
        continuousActionsOut[3] = Input.GetAxis("Vertical");
    }
}
