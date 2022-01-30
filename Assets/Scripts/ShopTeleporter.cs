using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopTeleporter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Blob blobScript = other.gameObject.GetComponent<Blob>();
        Transform blobTransform = other.gameObject.transform;
        if (blobScript != null)
        {
            blobScript.StopAllCoroutines();
            blobTransform.position = new Vector3(blobTransform.position.x, 0, -4);
            blobScript.goToBattle();
        }
    }
}
