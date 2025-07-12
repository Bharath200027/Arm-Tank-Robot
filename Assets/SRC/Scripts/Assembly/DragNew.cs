using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshCollider))]

public class DragNew : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public enum MovementAxis { SidewaysAndUpDown = 0, Sideways = 1, UpDown = 2 }
    public MovementAxis Axes = MovementAxis.SidewaysAndUpDown;


    void OnMouseDown()
    {

        /*GameObject.Find("AssemblyWorkBench").SendMessage("DisplayText", int.Parse(tag.Trim()));*/

        float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
        if (dist < 50f)
        {
            if (Axes == MovementAxis.SidewaysAndUpDown)
            {
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            }
            else if (Axes == MovementAxis.Sideways)
            {
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
            }
            else if (Axes == MovementAxis.UpDown)
            {
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
            }
        }
    }

    void OnMouseDrag()
    {
        float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
        if (dist < 50f)
        {
            if (Axes == MovementAxis.SidewaysAndUpDown)
            {
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = curPosition;
            }
            else if (Axes == MovementAxis.Sideways)
            {
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);

                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = curPosition;
            }
            else if (Axes == MovementAxis.UpDown)
            {
                Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);

                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = curPosition;
            }
        }
    }


    void OnMouseUp()
    {
        //GameObject.Find("AssemblyWorkBench").SendMessage("DisplayText", int.Parse(tag.Trim()));
        transform.position = new Vector3(gameObject.GetComponentInChildren<Transform>().position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }


}
