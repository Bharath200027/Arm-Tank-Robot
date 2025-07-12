using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPObjectPickUp : MonoBehaviour
{
    public GameObject Finish, Done;
    public GameObject ParticleEffect;
    public GameObject BEInfoStack;
    bool contactstatus;
    bool objectstatus;

    private void Update()
    {
        contactstatus = BEInfoStack.GetComponent<GripperClamp>().gripperstatus;

        if (objectstatus && contactstatus)
        {
            Finish.SetActive(true);
            Done.SetActive(true);
            ParticleEffect.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TargetCube")
        {
            objectstatus = true;
        }

    }
}
