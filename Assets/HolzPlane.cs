using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolzPlane : MonoBehaviour
    {

    private bool isOccupied;

    // Start is called before the first frame update
    public void setOccupied(bool b) {
    isOccupied = b;


}

    public bool getOccupied() {
        return isOccupied;
        
    }
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
