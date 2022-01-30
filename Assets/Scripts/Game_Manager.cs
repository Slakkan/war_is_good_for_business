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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform && raycastHit.transform.gameObject.tag == "Item")
                {
                    onItemClicked(raycastHit.transform.gameObject.GetComponent<Item>());
                }
            }
        }

        if(!isShopBusy)
        {

        }
    }



    private void onItemClicked (Item item)
    {

    }

    private void moveToShop(GameObject blob)
    {
        Blob blobScript = blob.gameObject.GetComponent<Blob>();
        blobScript.StopAllCoroutines();

        float finalX = blob.tag == "Hero" ? -5 : 5;
        Vector3 destination = new Vector3(finalX, 10, -4);
        blobScript.moveTo(destination);
    }
}
