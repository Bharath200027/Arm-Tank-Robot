using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperController : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    public GameObject joint6;
    public GameObject TargetObject, particleEffect;
    public GameObject obj, objbtn;
    private float x;
    /*public GameObject Attached, Initial;*/
    void Start()
    {
        smr = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (x < 100)
            {
                if (joint6.GetComponent<ObjectPickupBehaviour>().contact && x>32)
                {
                    particleEffect.SetActive(false);
                    TargetObject.transform.parent = joint6.gameObject.transform;
                    /*TargetObject.GetComponent<Rigidbody>().isKinematic = true;*/
                    TargetObject.GetComponent<Rigidbody>().useGravity = false;
                    TargetObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                    /*TargetObject.GetComponent<BoxCollider>().isTrigger = true;*/
                    obj.SetActive(true);
                    objbtn.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    x++;
                    smr.SetBlendShapeWeight(0, x);
                    smr.SetBlendShapeWeight(1, x);
                }
                
            }
        }

         if (Input.GetKey(KeyCode.E))
         {
            if (x > 0)
            {
                if (joint6.GetComponent<ObjectPickupBehaviour>().contact)
                {
                    TargetObject.transform.position = TargetObject.transform.position;
                    particleEffect.SetActive(true);
                    /*TargetObject.GetComponent<Rigidbody>().isKinematic = false;*/
                    TargetObject.GetComponent<Rigidbody>().useGravity = true;
                    TargetObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                    /*TargetObject.GetComponent<BoxCollider>().isTrigger = false;*/
                }
                x--;
                smr.SetBlendShapeWeight(0, x);
                smr.SetBlendShapeWeight(1, x);
            }
         }
    }
}
