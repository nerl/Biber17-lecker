using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class mainCameraScript : MonoBehaviour
{

    float mouseX, mouseY;
    float cameraRotationX, cameraRotationY;
    float speed = 1.5f;
    Vector3 start = new Vector3(-4.11f, 12, -184f);
    Vector3 end = new Vector3(-4.11f, 12, -24f);
    public LevelManager LevelManagerListener;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start;
        StartCoroutine(intro());


    }

    // Update is called once per frame
    Vector3 Pos1 = new Vector3(-16, 9, -18);
    Vector3 Pos2 = new Vector3(16, 9, -18);

    void Update()

    {
        if (Input.GetKey(KeyCode.RightControl) ) {

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



        
        
        //transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);

    }
    
    IEnumerator intro() {
        
            

        float journey = 0f;
        float duration = 2f;
        float smoothTime = 0.2F;
        Vector3 velocity = Vector3.zero;

        while (journey <= duration) {
            journey = journey + Time.deltaTime;
            
            transform.position = Vector3.SmoothDamp(transform.position, end , ref velocity, smoothTime);
            yield return null;


        }
        
    }
}
