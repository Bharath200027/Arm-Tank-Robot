using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMotionBehaviour : MonoBehaviour
{
    Rigidbody robot;
    int speedr = 10;
    int speedm = 5;
    public GameObject[] wheelLeft, wheelRight;

    void Start()
    {
        robot = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            robot.velocity = transform.right * -speedm;
            wheelLeft[0].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            wheelLeft[1].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            wheelRight[0].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            wheelRight[1].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            robot.velocity = transform.right * speedm;
            wheelLeft[0].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            wheelLeft[1].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            wheelRight[0].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            wheelRight[1].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up * -speedr * Time.deltaTime);
            wheelLeft[0].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            wheelLeft[1].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            wheelRight[0].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            wheelRight[1].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * speedr * Time.deltaTime);
            wheelLeft[0].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            wheelLeft[1].transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            wheelRight[0].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            wheelRight[1].transform.Rotate(Vector3.back * 100 * Time.deltaTime);
        }
    }
}
