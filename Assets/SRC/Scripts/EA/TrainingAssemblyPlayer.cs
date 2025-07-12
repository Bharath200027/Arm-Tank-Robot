using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingAssemblyPlayer : MonoBehaviour
{
    public GameObject BackBtn, ResetBtn, Instruction, StartInst, StartBtn;
    public GameObject Robot;
    public void DoneButton()
    {
        SceneManager.LoadScene("EA");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("LoadUI");
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartButton()
    {
        /*Camera.main.GetComponent<MouseLook>().enabled = true;*/
        Robot.GetComponent<AssemblyWorkTable>().enabled = true;
        BackBtn.gameObject.SetActive(true);
        ResetBtn.gameObject.SetActive(true);
        Instruction.gameObject.SetActive(true);
        StartBtn.gameObject.SetActive(false);
        StartInst.gameObject.SetActive(false);
    }

}
