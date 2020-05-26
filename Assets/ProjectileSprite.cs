using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileSprite : MonoBehaviour
{

    //
    public string huhuh;

    public void SetSprite(Sprite sprite) {
        this.GetComponent<SpriteRenderer>().sprite = sprite;


    }


    private void OnMouseDown() {
        Debug.Log("huhuhuhu");
            
        
    }
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
