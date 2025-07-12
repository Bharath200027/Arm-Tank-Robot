using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickupBehaviour : MonoBehaviour
{
    public bool contact;
    // Start is called before the first frame update
    void Start()
    {
        contact = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Initial")
        {
            contact = true;
            
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Initial")
        {
            contact = false;
            other.transform.parent = this.gameObject.transform;
            particleeffect.SetActive(true);
        }
    }*/
}
