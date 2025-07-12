using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBehaviour : MonoBehaviour
{
    private GameObject robotPrefab;
    void Start()
    {
        robotPrefab = Resources.Load<GameObject>("Robot/prefab/ROBOT");
        GameObject robot = Instantiate(robotPrefab);
        robot.transform.position = this.transform.position;
    }
}
