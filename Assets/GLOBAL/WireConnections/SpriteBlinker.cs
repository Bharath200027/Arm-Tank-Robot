using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBlinker : MonoBehaviour
{

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponentInChildren<SpriteRenderer>();
        if(sr==null)
        {
            return;
        }

        StartCoroutine(Blink());
      
    }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator Blink()
        {
           
                sr.enabled = true;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = false;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = true;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = false;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = true;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = false;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = true;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = false;
                yield return new WaitForSeconds(0.5f);
                sr.enabled = true;
                //Destroy(this.gameObject);



    }


   
    
}
