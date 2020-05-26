using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MoveScript : MonoBehaviour {

    [SerializeField]
    private float start = 0;

    [SerializeField]
    private float end = 50;
    [SerializeField]
    [Range(0f, 1f)]
    private float lerpPercent = 0.5f;

    public float finalValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalValue = Mathf.Lerp(start, end, lerpPercent);
        //GameObject.Find("Cube").transform.position = new Vector3()



    }
}
