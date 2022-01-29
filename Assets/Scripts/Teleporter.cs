using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum TeleporterPosition
{
    left,
    right
}
public class Teleporter : MonoBehaviour
{
    [SerializeField] TeleporterPosition tp;
    [SerializeField] Game_Manager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hero" && tp == TeleporterPosition.left || other.tag == "Villain" && tp == TeleporterPosition.right)
        {
            Transform blobTransform = other.gameObject.transform;
            Blob blobScript = other.gameObject.GetComponent<Blob>();

            blobScript.StopAllCoroutines();
            float finalX = other.tag == "Hero" ? -5 : 5;
            blobTransform.position = new Vector3(blobTransform.position.x, 10, -4);
            Vector3 destination = new Vector3(finalX, 10, -4);
            blobScript.moveTo(destination);
        }
        if(other.tag == "Hero" && tp == TeleporterPosition.right)
        {
            Blob blobScript = other.gameObject.GetComponent<Blob>();
            gameManager.duality = gameManager.duality + blobScript.health;
            Debug.Log(gameManager.duality);
        }
        if (other.tag == "Villain" && tp == TeleporterPosition.left)
        {
            Blob blobScript = other.gameObject.GetComponent<Blob>();
            gameManager.duality = gameManager.duality - blobScript.health;
            Debug.Log(gameManager.duality);
        }
    }
}
