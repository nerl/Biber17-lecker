using System;
using System.Collections;
using System.Collections.Generic;

using System.Xml;

using UnityEditor.Experimental.U2D;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.WSA.Input;

//[ExecuteInEditMode]

public class Projectile : MonoBehaviour {

    //bool moveable = false;
    public LevelManager levelManagerListener;

    public float speed = 0.5F;
    [SerializeField]
    float duration = 1.25f;
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform target;
    //[SerializeField]
    Transform control;
    [SerializeField]
    //ProjectileText projectileText;

    private int sequencePosition;
    [SerializeField]
    private ProjectileSprite  sprite;

    //public float tValue;
    //[SerializeField]
    //[Range(0f, 1f)]
    //private float lerpPercent = 0.5f;
    // Time when the movement started.
    //private float startTime;
    // Total distance between the markers.
    //float distance;



    public void setSequencePosition(int i) {
        sequencePosition = i;
    }
    public int getSequencePosition() {
        return sequencePosition;
    }



    public void SetSprite (Sprite s) {
        this.GetComponent<SpriteRenderer>().sprite = s;
    }

    private void OnMouseDown() {
        /*
        if (1 == 2)
            if ((transform.position - target.position).magnitude < (transform.position - start.position).magnitude) {
                StartCoroutine(MoveOnCurve(target, start));
            }
            else {
                StartCoroutine(MoveOnCurve(start, target));
            }
        levelManagerListener.checkForNotOccupied(gameObject);
        */

    }
    // Start is called before the first frame update

    public void Move(Transform start, Transform target) {
        StartCoroutine(MoveOnCurve(start, target));
    }

    /*
    void setBezierPositions(Transform start, Transform target, Transform control) {
        this.start = start;
        this.target = target;
        this.control = control;
        transform.position = start.position;
    }
    */

    /*
    Vector3 getStartPosition() {
        return start.position;
    }
    */
    /*
    Vector3 getTargetPosition() {
        return start.position;
    }
    */



    public void setText(String s) {
        //projectileText.setText(s);
    }

    void Start() {

        start = new GameObject().transform;
        start.position = transform.position;
        start.name = "Start";

        target = new GameObject().transform;
        target.transform.position = new UnityEngine.Vector3(5f, 0.5f, 5f);
        target.name = "Target";

    }

    void Update() {
        // 
        /*
        if (moveable) {
            //Vector v = new Vector3 (Vector3.forward * 20f, 40f, 0)
            UnityEngine.Vector3 v = new UnityEngine.Vector3(20f, 100f, 0);
            rb.AddForce(v);
            moveable = false;
        }
        /
        //transform.position = Vector3.Lerp(new Vector3(0, 0, 0.1f), new Vector3(0, 10, 0.5f), lerpPercent);
        //transform.LookAt(target);
        // transform.rotation= Quaternion.Lerp(start.rotation, target.rotation, lerpPercent);
        /*
        // Compute the distance to the target
        float dist = (target.transform.position - transform.position).magnitude;
        // ...and the fraction (t) of how far we are along the path
        float t = Mathf.Clamp01(1 - (dist / distance));
        // Use this to arc (rotate up) the projectile
        float arc = Mathf.LerpAngle(0, 10, t);
        transform.Rotate(0, 0, arc);
        // Move forward
        transform.Translate(UnityEngine.Vector3.forward * speed * Time.deltaTime);
        */
    }



    //    start* (1-t)^2+2*control1* t*(1-t)+end* (t)^2

    private void LookInMovemementDirection() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);
    }


    /*
    private Vector3 getCurvePoint(float t, Vector3[] transforms) {

        String s = "Start " + transforms[0].ToString()
        + "\nMitte " + transforms[1].ToString()
        + "\nEnde  " + transforms[2].ToString()
        + "\nt: " + t;
        ;
        

        float x, y, z;
        Vector3 result = new Vector3(0, 1, 2);
        for (int i = 0; i < 3; i++) {
            result[i] = transforms[0][i] * (1 - t) * (1 - t) + 2 * transforms[1][i] * t * (1 - t) + transforms[2][i] * t * t;
            //Alert ("result[" + i + "] " + result[i].ToString());
        }

        
        
        

            return result;
    }
    */





    private Vector3 Bezier2(Vector3 Start, Vector3 Control, Vector3 End, float t) {
        return (((1 - t) * (1 - t)) * Start) + (2 * t * (1 - t) * Control) + ((t * t) * End);
    }


    private IEnumerator MoveOnCurve(Transform start, Transform target) {
        Vector3[] transforms = new Vector3[3];
        transform.position = start.position;
        transforms[0] = start.position;
        transforms[1] = new Vector3((start.position - target.position).magnitude / 2f, UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(-10f, 20f));
        transforms[2] = target.position;
        float distance = (start.position - target.position).magnitude;
        float t;
        float journey = 0f;
        Rigidbody rb = GetComponent<Rigidbody>();
        //duration = 2f;
        while (journey <= duration) {
            journey = journey + Time.deltaTime;

            t = Mathf.Clamp01(journey / duration);
            transform.position = Bezier2(start.position, transforms[1], target.position + new Vector3(0, 0.5f, -0.5f), t);
            Vector3 movement = new Vector3(transform.position.x, 0.0f, transform.position.y);
            transform.rotation = Quaternion.LookRotation(movement);
            //            rb.AddTorque(transform.up * 2 * 3f);

            Debug.Log(transform.position);
            Debug.Log("Mathf.Clamp01(journey / duration): journey: " + journey + " duration: " + duration + "--> " + Mathf.Clamp01(journey / duration));
            yield return null;
        }

       


    }
  
}
