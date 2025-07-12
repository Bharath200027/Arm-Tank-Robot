using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EAPlayer : MonoBehaviour
{
    public void DoneButton()
    {
        SceneManager.LoadScene("BP");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Assembly");
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
