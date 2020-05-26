using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEditor;

public class UtilFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    static UtilFunctions() {

    }

    /// <summary>
    /// shows dialogform modal ->  Aufruf UtilFunctions.Alert("");
    /// </summary>
    ///  <param name="message">der String, der Ausgegeben wird.
    /// </param>
    public static void Alert (string message) {
        EditorUtility.DisplayDialog("Alert",  message , "Ok");
    }
}
