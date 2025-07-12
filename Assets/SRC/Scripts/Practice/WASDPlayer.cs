using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDPlayer : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Forward", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Backward", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("ACW", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("CW", true);
        }
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetFloat("LiftFloat", 1);
        }*/

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) /*&& !Input.GetKey(KeyCode.UpArrow))*/
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backward", false);
            animator.SetBool("ACW", false);
            animator.SetBool("CW", false);
            /*animator.SetFloat("LiftFloat", 0);*/
        }
        /*if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Back", false);
        }
        if (!Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("ACW", 0);
        }
        if (!Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("CW", 0);
        }
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetFloat("LiftFloat", 0);
        }
        if (!Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("Drop", 0);
        }*/
    }

}
