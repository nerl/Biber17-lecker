using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ZweigSprite : MonoBehaviour {

    bool moveable = false;
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
    ProjectileText projectileText;

    private int sequencePosition;
    [SerializeField]
    private ProjectileSprite sprite;
    private Sprite mySprite;

    public readonly float heightPosition =3.8f;

    /// <summary>
    /// legt die tatsächliche Position auf dem Feld 
    /// </summary>
    /// <param name="i"></param>
    public void SetSequencePosition(int i) {
        sequencePosition = i;
    }
    /// <summary>
    /// liefert dit tasächliche Position auf dem Feld
    /// </summary>
    /// <returns></returns>
    public int GetSequencePosition() {
        return sequencePosition;
    }


    /// <summary>
    /// setzt das aktuelle Sprite Bild 
    /// </summary>
    /// <param name="s"></param>
    public void SetSprite(Sprite s) {
        this.GetComponent<SpriteRenderer>().sprite = s;
        mySprite = s;
    }

    public Sprite GetSprite () {
        return mySprite;
    }

    /// <summary>
    /// überprüft, nach Mausdruck, welcher Platz auf dem Feld nicht besetzt ist.
    /// </summary>
    private void OnMouseDown() {
        /*
        if (1 == 2)
            if ((transform.position - target.position).magnitude < (transform.position - start.position).magnitude) {
                StartCoroutine(MoveOnCurve(target, start));
            }
            else {
                StartCoroutine(MoveOnCurve(start, target));
            }
        */
        levelManagerListener.checkForNotOccupied(gameObject);


    }


    public void SetLevelManagerListener (LevelManager lm) {
        levelManagerListener = lm;
    }

    /// <summary>
    /// bewegt von start nach target in einer Corroutine
    /// </summary>
    /// <param name="start"></param>
    /// <param name="target"></param>
    public void Move(Transform target) {
        StartCoroutine(MoveOnCurve(target.position));
    }


    void Start() {
    
    }


    void Update() {

    }



    /// <summary>
    /// 
    /// </summary>
    private void LookInMovemementDirection() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Start"></param>
    /// <param name="Control"></param>
    /// <param name="End"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    private Vector3 Bezier2(Vector3 Start, Vector3 Control, Vector3 End, float t) {
        return (((1 - t) * (1 - t)) * Start) + (2 * t * (1 - t) * Control) + ((t * t) * End);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    private IEnumerator MoveOnCurve(Vector3 target) {
        //Vector3[] transforms = new Vector3[3];
        target.y = heightPosition;

        Vector3 control = new Vector3((transform.position - target).magnitude / 2f, UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(-10f, 20f)); ;
      

        float t;
        float journey = 0f;
        //Rigidbody rb = GetComponent<Rigidbody>();
        //duration = 2f;
        while (journey <= duration) {
            journey = journey + Time.deltaTime;
            t = Mathf.Clamp01(journey / duration);
            transform.position = Bezier2(transform.position, control, target + new Vector3(0, 0, 0), t);      // 
            //Vector3 movement = new Vector3(transform.position.x, 0.0f, transform.position.y);
            transform.rotation = Quaternion.identity;
            //Quaternion.LookRotation(movement);

            Debug.Log("Hello World");
            //Debug.Log(transform.position);
            //Debug.Log("Mathf.Clamp01(journey / duration): journey: " + journey + " duration: " + duration + "--> " + Mathf.Clamp01(journey / duration));
            yield return null;
        }




    }

}


