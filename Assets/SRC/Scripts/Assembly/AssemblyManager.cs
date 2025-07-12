using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyManager : MonoBehaviour
{
    public GameObject _mainModel;
    
    public string[] Tags;

    public List<GameObject> _partPrefabs;

    public MeshRenderer[] _mainModelMeshRenderers;

    public GameObject PartHolder;

    //public MenuBuilder menuBuilder;
    public AssemblyWorkTable _assemblyWorkTable;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i<Tags.Length; i++)
        {
            GameObject[] gameObjectsWithTag; 
            gameObjectsWithTag = GameObject.FindGameObjectsWithTag(Tags[i]);
            if(gameObjectsWithTag.Length>0)
            {
                for(int j = 0; j<gameObjectsWithTag.Length; j++)
                {
                    GameObject gO = Instantiate(gameObjectsWithTag[j], PartHolder.transform.position, gameObjectsWithTag[j].transform.rotation);
                    gO.AddComponent<OnDestroyPartPrefab>();
                    gO.AddComponent<DragNew>();
                    _partPrefabs.Add(gO);
                    gameObjectsWithTag[j].AddComponent<OnCollisionFromPart>();
                }
            }
        }

        foreach(GameObject gO in _partPrefabs)
        {
            MeshRenderer[] _meshRenderers = gO.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                _meshRenderers[i].enabled = true;
            }
        }

        if (_assemblyWorkTable != null)
        {
            _assemblyWorkTable.SetGOList(_partPrefabs);
        }
    }
}
