using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public GameObject Finish, Done;
    public GameObject joint6, ParticleEffect;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Initial")
        {
            if (joint6.GetComponent<ObjectPickupBehaviour>().contact)
            {
                Finish.SetActive(true);
                Done.SetActive(true);
                ParticleEffect.SetActive(false);
            }
                
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Initial")
        {
            if (joint6.GetComponent<ObjectPickupBehaviour>().contact)
            {
                Finish.SetActive(true);
                Done.SetActive(true);
                ParticleEffect.SetActive(false);
            }

        }
    }
}
