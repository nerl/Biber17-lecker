using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditorInternal;
using System.Linq;


public class LevelManager : MonoBehaviour {

    public List<ZweigSprite> ZweigSpriteList = new List<ZweigSprite>();
    public List<HolzPlane> HolzPlaneList = new List<HolzPlane>();

    //public GameObject zweigPrefab;
    public Projectile ProjectilePrefab;
    public ZweigSprite zweigSpritePrefab;


    public HolzPlane holzPlane;  // = new HolzPlane().GetComponent<HolzPlane>();

    private SpriteCollection spriteCollection;



    public void checkForNotOccupied(GameObject go) {
        /*
        String s = "";
        for (int i = 0; i < HolzPlaneList.Count; i++) {
            s = s + "\n" + i + " isOccupied:" + HolzPlaneList[i].getOccupied();
        }
        Alert(s);
        */
        ZweigSprite tempZweig = go.GetComponent<ZweigSprite>();
        for (int i = 0; i < HolzPlaneList.Count; i++) {
            if (HolzPlaneList[i].getOccupied()) {
                // Alert(i + " isOccupied " + HolzPlaneList[i].isOccupied);
            }
            else {
                tempZweig.Move(HolzPlaneList[i].transform);
                HolzPlaneList[i].setOccupied(true);
                HolzPlaneList[tempZweig.GetSequencePosition()].setOccupied(false);
                tempZweig.SetSequencePosition(i);
                //tempProjectile.setText(":" + i);
                break;
            }
        }

    }
    /// <summary>
    /// Krass 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    private void DestroyPrefab ( IEnumerable<MonoBehaviour> destroyList ) 
    {
        foreach (var tmpDestroy in destroyList) 
        {
            GameObject go = tmpDestroy.gameObject;
            go.SetActive(false);
            Destroy(go, 3);
        }

    }

    //void DestroyList (IList<MonoBehaviour> list ) {
    //    foreach (var go in list) {
    //        go.SetActive(false);
    //        Destroy(go, 3);
    //    }
    //}

    public void NewGame() {
        //DestroyList(HolzPlaneList);

        DestroyPrefab(HolzPlaneList);
        DestroyPrefab(ZweigSpriteList);



        //for (int i = 0; i < ZweigSpriteList.Count; i++) {
        //    DestroyPrefab(ZweigSpriteList[i].gameObject);
        //}
        //for (int i = 0; i < HolzPlaneList.Count; i++) {
        //    DestroyPrefab(HolzPlaneList[i].gameObject);
        //}




        ZweigSpriteList = new List<ZweigSprite>();
        HolzPlaneList.Clear();
        //HolzPlaneList = new List<HolzPlane>();

        //UtilFunctions.Alert("ZweigSpriteList.Count: " + ZweigSpriteList.Count );

        //UtilFunctions.Alert(spriteCollection.sprites.Length + "");
        //UtilFunctions.Alert(spriteCollection.GetSpriteName(1));

        //3,5,4,1,2
        List<int> numbers = new List<int>();
        List<int> sequence = new List<int>();
        for (int i = 0; i < 5; i++) {
            numbers.Add(i);
            //UtilFunctions.Alert("" + i);
        }
        System.Random zufall = new System.Random();


        while (numbers.Count > 0) {
            int i = zufall.Next(0, numbers.Count - 1);

            sequence.Add(numbers[i]);
            //UtilFunctions.Alert("adding " + numbers[i]);
            numbers.RemoveAt(i);
        }
        String s = "";
        for (int i = 0; i < sequence.Count; i++) {
            s = s + "\n" + sequence[i];
        }
        //UtilFunctions.Alert(s);


        float startX = -15;

        for (int i = 0; i < 6; i++) {
            startX = startX + 5f;
            if (i > 0) {

                ZweigSprite zweigSprite = Instantiate(zweigSpritePrefab, new Vector3(startX, 0.5f, 0), Quaternion.identity);
                zweigSprite.transform.position = zweigSprite.transform.position + new Vector3(0f, zweigSprite.heightPosition, 0f);

                zweigSprite.SetSequencePosition(i);
                zweigSprite.SetLevelManagerListener(this);
                zweigSprite.name = "Zweig  " + sequence[i - 1];       // wir müssen i dekrementieren, weil wir ja die Zählung ab der ersten Bodenposition haben, welches als Stack verwendet wird
                zweigSprite.SetSprite(spriteCollection.GetSprite("blaetter_" + (sequence[i - 1])));
                ZweigSpriteList.Add(zweigSprite);
            }





            HolzPlane hp = Instantiate(holzPlane, new Vector3(startX, 0.01f, 0), Quaternion.identity);
            hp.name = "Holzplane" + i;
            hp.setOccupied(true);
            if (i == 0) {
                hp.setOccupied(false);
            }

            HolzPlaneList.Add(hp);
        }
    }

    


    // Start is called before the first frame update
    void Start() {
        spriteCollection = new SpriteCollection("blaetter");
        NewGame();

    }

    // Update is called once per frame
    void Update() {

    }






    IEnumerator MoveToPosition(Projectile projectile, Vector3 startPosition, Vector3 endPosition) {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);
        projectile.transform.Translate(new Vector3(5f, 5f, 5f));

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(10f, 2f, 3f));
        Debug.Log("move to position");

        yield return null;

    }


    /*
        float gravity = 60f;

    IEnumerator SimulateProjectileCR(Transform projectile, Vector3 startPosition, Vector3 endPosition) {
        projectile.position = startPosition;
        float arcAmount = 8f;
        float heightOfShot = 12f;
        Vector3 newVel = new Vector3();
        // Find the direction vector without the y-component
        Vector3 direction = new Vector3(endPosition.x, 0f, endPosition.z) - new Vector3(startPosition.x, 0f, startPosition.z);
        // Find the distance between the two points (without the y-component)
        float range = direction.magnitude;

        // Find unit direction of motion without the y component
        Vector3 unitDirection = direction.normalized;
        // Find the max height

        float maxYPos = startPosition.y + heightOfShot;

        // if it has, switch the height to match a 45 degree launch angle
        if (range / 2f > maxYPos)
            maxYPos = range / arcAmount;
        //fix bug when shooting on tower
        if (maxYPos - startPosition.y <= 0) {
            maxYPos = startPosition.y + 2f;
        }
        //fix bug caused if we can't shoot higher than target
        if (maxYPos - endPosition.y <= 0) {
            maxYPos = endPosition.y + 2f;
        }
        // find the initial velocity in y direction
        newVel.y = Mathf.Sqrt(-2.0f * -gravity * (maxYPos - startPosition.y));
        // find the total time by adding up the parts of the trajectory
        // time to reach the max
        float timeToMax = Mathf.Sqrt(-2.0f * (maxYPos - startPosition.y) / -gravity);
        // time to return to y-target
        float timeToTargetY = Mathf.Sqrt(-2.0f * (maxYPos - endPosition.y) / -gravity);
        // add them up to find the total flight time
        float totalFlightTime = timeToMax + timeToTargetY;
        // find the magnitude of the initial velocity in the xz direction
        float horizontalVelocityMagnitude = range / totalFlightTime;
        // use the unit direction to find the x and z components of initial velocity
        newVel.x = horizontalVelocityMagnitude * unitDirection.x;
        newVel.z = horizontalVelocityMagnitude * unitDirection.z;

        float elapse_time = 0;
        while (elapse_time < totalFlightTime) {

            projectile.Translate(newVel.x * Time.deltaTime, (newVel.y - (gravity * elapse_time)) * Time.deltaTime, newVel.z * Time.deltaTime);
            elapse_time += Time.deltaTime;
            yield return null; //yield return null will wait until the next frame and then continue execution. In your case it will check the condition of your while loop the next frame. ... Without yield return null it just executes trough the while loop in one frame.
        }


    }






    IEnumerator SimulateProjectile(Transform bullet, Vector3 startPosition, Vector3 endPosition) {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        float gravity = 1.8f;
        
        float firingAngle = 45.0f;






        // Move projectile to the position of throwing object + add some offset if needed.
        bullet.position = startPosition + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(startPosition, endPosition);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        bullet.rotation = Quaternion.LookRotation(endPosition - bullet.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration) {
            bullet.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }





    }*/
}





