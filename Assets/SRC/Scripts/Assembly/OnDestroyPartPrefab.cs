using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyPartPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameObject.Find("AssemblyWorkBench").SendMessage("SpawnNextIndexOf", int.Parse(gameObject.tag.Trim()));
    }

}
