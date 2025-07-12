using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticePlayer : MonoBehaviour
{
    public GameObject StartBtn, Startp, BackBtn, ResetBtn, Obj, ObjBtn;

    private void Start()
    {
        Time.timeScale = 0;
    }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartButton()
    {
        Startp.SetActive(false);
        StartBtn.SetActive(false);
        BackBtn.SetActive(true);
        ResetBtn.SetActive(true);
        Time.timeScale = 1;
    }

    public void ObjectBtn()
    {
        ObjBtn.SetActive(false);
        Obj.SetActive(false);
        Time.timeScale = 1;
    }
}
