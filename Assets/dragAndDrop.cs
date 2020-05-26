using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour
{
    private Vector3 mOffset;


    private float mZCoord;
    GameObject stack;

    void OnMouseDown() {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Debug.Log ("mZCoord: " + mZCoord);
        mZCoord = GameObject.Find("Cube").transform.position.z;

        stack = GameObject.Find("Cube");


        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        
        Debug.Log ("mOffset : " + mOffset.ToString());

    }


    private Vector3 GetMouseAsWorldPoint() {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;


        // z coordinate of game object on screen

        mousePoint.z = mZCoord;


        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }


    void OnMouseDrag() {

        transform.position = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(stack.transform.position.x, transform.position.y, 0);
        transform.rotation = Quaternion.identity;
        if (transform.position.y<10) {
            //transform.position.y = 10;
        }
        
    
    }
}

