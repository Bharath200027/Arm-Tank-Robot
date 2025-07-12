using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMode : MonoBehaviour
{
    static public bool Training, Practice = false;
    public GameObject Hints, ConnectionManager;
    public bool PMode;
    // Start is called before the first frame update
    public void TrainingMode()
    {
        Training = true;
        Practice = false;
    }

    public void PracticeMode()
    {
        Training = false;
        Practice = true;
    }

    void Start()
    {
        if (Training)
        {
            Hints.SetActive(true);
            PMode = false;
        }
        if (Practice)
        {
            Hints.SetActive(false);
            PMode = true;
        }
    }

    private void Update()
    {
        if (Practice)
        {
            PMode = true;
        }
        
        if (Training)
        {
            PMode = false;
        }
    }
}
