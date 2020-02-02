using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpToPositionOnCollide : MonoBehaviour
{
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Find current object's name
        var currentObject = gameObject.name;
        //Find Object we're collinding with
        var objectWeAreHitting = other.gameObject.name;
        //Check if we're colliding with the correct object
        if (currentObject + "_outline" == objectWeAreHitting)
            //Do the SLERP
            StartCoroutine(moveToPosition(gameObject, other.gameObject, 2.0f));
    }

    IEnumerator moveToPosition(GameObject fromPositionObject, GameObject toGameObject, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPositionObject.transform.position;
        Quaternion startRotation = fromPositionObject.transform.rotation;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPositionObject.transform.position = Vector3.Slerp(startPos, toGameObject.transform.position, counter / duration);
            fromPositionObject.transform.rotation = Quaternion.Slerp(startRotation, toGameObject.transform.rotation, counter / duration);
            yield return null;
        }

        fromPositionObject.GetComponent<MeshCollider>().enabled = false;
        isMoving = false;
    }
}
