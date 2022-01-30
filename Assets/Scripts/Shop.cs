using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Blob currentClient;
    void Start()
    {
        
    }

    void Update()
    {
        if (currentClient != null && Input.GetMouseButtonDown(0))
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
    }

    private void onItemClicked(Item item)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        currentClient = other.gameObject.GetComponent<Blob>();
    }
}
