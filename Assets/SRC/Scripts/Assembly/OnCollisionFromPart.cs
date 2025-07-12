using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionFromPart : MonoBehaviour
{

    private MeshRenderer[] _meshRenderers;

    private void Start()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i<_meshRenderers.Length; i++)
        {
            _meshRenderers[i].enabled = false;
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == this.gameObject.tag)
        {
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < _meshRenderers.Length; i++)
            {
                _meshRenderers[i].enabled = true;
            }
            Destroy(other.gameObject);
        }

       
    }
}
