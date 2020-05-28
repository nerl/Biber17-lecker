using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectileText : MonoBehaviour
{



    // Start is called before the first frame update
    public void setText (string s) {
        GetComponent<TextMeshPro>().text = s;
         //= s;
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
