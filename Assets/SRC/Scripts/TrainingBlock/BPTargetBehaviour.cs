using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPTargetBehaviour : MonoBehaviour
{
    public GameObject effect1, effect2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TargetRobot")
        {
            effect1.SetActive(false);
            effect2.SetActive(true);
        }
    }
}
