using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInZoomOut: MonoBehaviour
{
    [SerializeField]
    private float ZoomSize = 3f;
    [SerializeField]
    private float speed = 20f;
    
    
    private float p = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Camera.main.orthographic)
        {
            var FOV = Camera.main.fieldOfView;
            FOV += Input.GetAxis("Mouse ScrollWheel") * 30f;
            FOV = Mathf.Clamp(FOV, 15f, 65f);
            Camera.main.fieldOfView = FOV;
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (ZoomSize > 0.08f)
                {
                    ZoomSize-=p;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (ZoomSize < 30)
                {
                    ZoomSize+=p;
                }
            }
        }
        if ((Input.GetKey(KeyCode.W)) ) 
        {
            GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z + Time.deltaTime * speed);
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z - Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {          
            GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x + Time.deltaTime * speed, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Camera>().transform.position = new Vector3(GetComponent<Camera>().transform.position.x - Time.deltaTime * speed, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z);
        }
        GetComponent<Camera>().orthographicSize = ZoomSize;
    }
}
