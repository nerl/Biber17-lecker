using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class TextCube : MonoBehaviour


{
    public TextOnCube textOnCube;
    public bool isOccupied = true;
    //public string text;


    public void SetText(string s) {
        textOnCube.GetComponent<TextMesh>().text = s;
    }

    private void OnMouseDown() {
       

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetText("" + Time.deltaTime);
        
    }
}
