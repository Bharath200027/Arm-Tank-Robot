using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

   
    public GameObject fpsCam, mainCam;
    public int CamMode;




    private void Start()
    {
        StartCoroutine(CamCtrl());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamCtrl());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            fpsCam.SendMessage("ToggleMovement", SendMessageOptions.DontRequireReceiver);

            Debug.Log("Toggle FPS Cam Lock");
        }

    }

    IEnumerator CamCtrl()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            fpsCam.SetActive(true);
            mainCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            fpsCam.SetActive(false);
            mainCam.SetActive(true);
        }
    }


}
