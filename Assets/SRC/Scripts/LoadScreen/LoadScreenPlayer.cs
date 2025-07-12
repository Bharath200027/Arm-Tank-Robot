using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenPlayer : MonoBehaviour
{
    public GameObject TrainingBtn, PracticeBtn, Back1Btn, StartBtn, QuitBtn;
    void Start()
    {
        StartBtn.gameObject.SetActive(true);;
        TrainingBtn.gameObject.SetActive(false);
        PracticeBtn.gameObject.SetActive(false);
        Back1Btn.gameObject.SetActive(false);

    }
    public void TrainingButton()
    {
        SceneManager.LoadScene("BP");
    }

    public void PracticeButton()
    {
        SceneManager.LoadScene("WASD");
    }

    public void StartButton()
    {
        StartBtn.gameObject.SetActive(false);
        TrainingBtn.gameObject.SetActive(true);
        PracticeBtn.gameObject.SetActive(true);
        Back1Btn.gameObject.SetActive(true);
    }

    public void QuitButton()
    {
        StartBtn.gameObject.SetActive(true);
        TrainingBtn.gameObject.SetActive(false);
        PracticeBtn.gameObject.SetActive(false);
        Back1Btn.gameObject.SetActive(false);
        Application.Quit();
    }

    public void Back1()
    {
        StartBtn.gameObject.SetActive(true);
        QuitBtn.gameObject.SetActive(true);
        TrainingBtn.gameObject.SetActive(false);
        PracticeBtn.gameObject.SetActive(false);
        Back1Btn.gameObject.SetActive(false);
    }
}
