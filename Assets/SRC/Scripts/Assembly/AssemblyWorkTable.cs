using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyWorkTable : MonoBehaviour
{

    public List<GameObject> _partPrefabs;
    public GameObject[] _partPrefabArray;
    public GameObject[] Hints;
    public GameObject Finish, Done;

    public string[] _partContent;
    
    public GameObject SpawnPoint;

    void Update()
    {
    }


    public void SetGOList(List<GameObject> _gameObjects)
    {
        _partPrefabs = _gameObjects;
        _partPrefabArray = _partPrefabs.ToArray();

        for(int i = 0; i < _partPrefabArray.Length; i++)
        {
            _partPrefabArray[i].SetActive(false);
        }

        SpawnObjects();

    }


    public void SpawnObjects()
    {
        SpawnNextIndexOf(-1);
    }

    public void SpawnNextIndexOf(int index)
    {
        
        if(_partPrefabArray!=null)
        {
            if (index < _partPrefabArray.Length-1)
            {
                for (int i = 0; i < _partPrefabArray.Length; i++)
                {
                    if (_partPrefabArray[i] != null)
                    {
                        _partPrefabArray[i].SetActive(false);
                        Hints[i].SetActive(false);
                    }
                }
                if (_partPrefabArray[index + 1] != null)
                {
                    _partPrefabArray[index + 1].SetActive(true);
                    Hints[index + 1].SetActive(true);
                }
            }
            else
            {
                Debug.Log("No More Parts after this!");
                Finish.SetActive(true);
                Done.SetActive(true);
            }
        }
    }
}
