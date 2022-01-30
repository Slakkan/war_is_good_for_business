using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public float duality = 50;

    public List<Blob> shopWaitingList = new List<Blob>();
    bool isShopBusy = false;
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
            moveToShop(nextCustomer.gameObject);
        }
    }



    private void moveToShop(GameObject blob)
    {
        Blob blobScript = blob.GetComponent<Blob>();
        blobScript.StopAllCoroutines();

        float finalX = blob.tag == "Hero" ? -5 : 5;
        Vector3 destination = new Vector3(finalX, 10, -4);
        blobScript.moveTo(destination);
    }
}
