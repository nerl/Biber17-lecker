using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiberBen : MonoBehaviour
{
    public LevelManager LevelManagerListener;

    private void OnMouseDown() {
        LevelManagerListener.NewGame();
        //UtilFunctions.Alert("Servus");
    }
}
