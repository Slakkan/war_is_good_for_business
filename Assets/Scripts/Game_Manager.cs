using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public float duality = 50;

    public List<Blob> shopWaitingList = new List<Blob>();
    public bool isShopBusy = false;

    Vector3 leftShopPortalPosition = new Vector3(-25, -9.5f, 0);
    Vector3 rightShopPortalPosition = new Vector3(25, -9.5f, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShopBusy && shopWaitingList.Count != 0)
        {
            isShopBusy = true;
            Blob nextCustomer = shopWaitingList[0];
            shopWaitingList.Remove(nextCustomer);
            StartCoroutine(moveToShop(nextCustomer.gameObject));
        }
    }

    public void moveToBattlefield (GameObject blob)
    {
        Blob blobScript = blob.GetComponent<Blob>();
        if (blob.tag == "Hero")
        {
            blobScript.moveTo(leftShopPortalPosition);
        }
         else if (blob.tag == "Villain")
        {
            blobScript.moveTo(rightShopPortalPosition);
        }
    }

    private IEnumerator moveToShop(GameObject blob)
    {
        Blob blobScript = blob.GetComponent<Blob>();

        float finalX = blob.tag == "Hero" ? -5 : 5;
        Vector3 destination = new Vector3(finalX, 10, -4);
        while (blobScript.animator.GetBool("isWalking"))
        {
            yield return null;
        }
        blobScript.moveTo(destination);
    }
}
