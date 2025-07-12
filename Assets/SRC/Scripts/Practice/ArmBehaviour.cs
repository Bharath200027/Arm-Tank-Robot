using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public GameObject[] arm;
    public GameObject wrist;
    int speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.UpArrow)) && ((arm[0].transform.rotation.z > -0.22) && (arm[0].transform.rotation.z < 0.43)))
        {
            arm[0].transform.Rotate(Vector3.back * speed * Time.deltaTime);
            arm[1].transform.Rotate(Vector3.back * speed * Time.deltaTime);
            wrist.transform.Rotate(Vector3.back * -speed * Time.deltaTime);
        }

        if ((Input.GetKey(KeyCode.DownArrow)) && ((arm[0].transform.rotation.z > -0.21) && (arm[0].transform.rotation.z < 0.45)))
        {
            arm[0].transform.Rotate(Vector3.back * -speed * Time.deltaTime);
            arm[1].transform.Rotate(Vector3.back * -speed * Time.deltaTime);
            wrist.transform.Rotate(Vector3.back * +speed * Time.deltaTime);
        }

/*        Debug.Log(arm[0].transform.rotation.z);*/
    }
}
