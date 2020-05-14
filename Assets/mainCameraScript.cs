using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour
{

    float mouseX, mouseY;
    float cameraRotationX, cameraRotationY;
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()

    {
        if (Input.GetKey(KeyCode.LeftControl) ) {

            cameraRotationY = (Input.mousePosition.x - mouseX) * 10 * Time.deltaTime;
            cameraRotationX = (Input.mousePosition.y - mouseY) * 10 * Time.deltaTime;
            this.transform.Rotate(0, cameraRotationY, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += -transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += transform.forward * Time.deltaTime * speed;
        }


        //}
        mouseX = Input.mousePosition.x;
        mouseY= Input.mousePosition.y;
    }

}
