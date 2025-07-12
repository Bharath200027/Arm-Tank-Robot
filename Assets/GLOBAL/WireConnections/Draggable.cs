using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Draggable : MonoBehaviour

{

    private Vector3 mOffset;
    bool firstPass = false;
    // bool stopFollowingMouse = false;



    private float mZCoord;


    private void Update()
    {

        if (CableConnectionManager.connectionSuccessful)
            Destroy(this);

        if (!CableConnectionManager.connectorStopMouseFollow)
        {
            if (!firstPass)
            {
                mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;



                // Store offset = gameobject world pos - mouse world pos

                mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
                firstPass = true;
            }
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
      
        //else
        //{
        //    Destroy(this);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (!CableConnectionManager.connectionSuccessful)
        //    {
        //        Destroy(this.transform.parent.gameObject);
        //    }
        //    stopFollowingMouse = true;
        //}
    }


   



    //void OnMouseDown()

    //{

    //    mZCoord = Camera.main.WorldToScreenPoint(

    //        gameObject.transform.position).z;



    //    // Store offset = gameobject world pos - mouse world pos

    //    mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    //}



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    //void OnMouseDrag()

    //{

    //    transform.position = GetMouseAsWorldPoint() + mOffset;

    //}

}