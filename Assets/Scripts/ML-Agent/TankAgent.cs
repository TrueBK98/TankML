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
    int count;

    public override void Initialize()
    {
        tankController = GetComponent<TankController>();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(tankController.hpController.currentValue);
        sensor.AddObservation(transform.position);
        sensor.AddObservation(tankController.gun.rotation);
        sensor.AddObservation(count);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actionX = Mathf.Clamp(actionBuffers.ContinuousActions[0], -1f, 1f);
        var actionY = Mathf.Clamp(actionBuffers.ContinuousActions[1], -1f, 1f);
        tankController.Move(new Vector3(actionX, actionY));

        var actionZ = Mathf.Clamp(actionBuffers.ContinuousActions[2], -1f, 1f);
        tankController.gun.transform.Rotate(0, 0, (actionZ * 100));

        var shoot = actionBuffers.DiscreteActions[0];

        if (shoot == 1 && count >= 20)
        {
            tankController.Shoot();
            count = 0;
        }

        if (count < 20)
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
        continuousActionsOut[2] = Input.GetAxis("Vertical");
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = Input.GetMouseButtonDown(0) ? 1 : 0;
    }
}
