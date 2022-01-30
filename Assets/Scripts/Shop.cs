using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Blob currentClient;
    [SerializeField] Game_Manager gameManager;

    Item badItem;
    Item mediumItem;
    Item qualityItem;

    [SerializeField] List<Item> badItemsList;
    [SerializeField] List<Item> mediumItemsList;
    [SerializeField] List<Item> qualityItemsList;
    void Start()
    {
        
    }

    void Update()
    {
        if (currentClient != null && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Raycasting");
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 800f))
            {
                Debug.Log("HIT");
                if (raycastHit.transform && raycastHit.transform.gameObject.tag == "Item")
                {
                    onItemClicked(raycastHit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        if(badItem == null)
        {
           int index = Random.Range(0, badItemsList.Count-1);
           badItem =  badItemsList[index];
           GameObject.Instantiate(badItem.gameObject);
        }
        if (mediumItem == null)
        {
            int index = Random.Range(0, mediumItemsList.Count -1);
            mediumItem = mediumItemsList[index];
            GameObject.Instantiate(mediumItem.gameObject);
        }
        if (qualityItem == null)
        {
            int index = Random.Range(0, qualityItemsList.Count -1);
            qualityItem = qualityItemsList[index];
            GameObject.Instantiate(qualityItem.gameObject);
        }
    }

    private void onItemClicked(Item item)
    {
        int length = item.name.Length - 9;
        string itemName = item.name.Substring(0, length);
        Debug.Log(itemName);
        currentClient.GetComponent<Blob>().equip(itemName);

        gameManager.moveToBattlefield(currentClient.gameObject);


        Destroy(item);

        currentClient = null;
        gameManager.isShopBusy = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED THE SHOP");
        currentClient = other.gameObject.GetComponent<Blob>();
    }
}
