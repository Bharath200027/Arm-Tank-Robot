using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BPPlayer : MonoBehaviour
{
    public GameObject Robot;
    public void DoneButton()
    {
        SceneManager.LoadScene("LoadUI");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("LoadUI");
    }

    public void ResetButton()
    {
        Robot.transform.position = new Vector3(11, 3, 25);
        Robot.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        Robot.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        Robot.GetComponent<Rigidbody>().isKinematic = false;
    }
}
