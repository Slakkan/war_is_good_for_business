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

    public IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hero" && tp == TeleporterPosition.left || other.tag == "Villain" && tp == TeleporterPosition.right)
        {
            Transform blobTransform = other.gameObject.transform;
            Blob blobScript = other.gameObject.GetComponent<Blob>();
            while(blobScript.animator.GetBool("isWalking"))
            {
                yield return null;
            }
            blobTransform.position = new Vector3(blobTransform.position.x, 10, -4);
            gameManager.shopWaitingList.Add(blobScript);
        }
        if(other.tag == "Hero" && tp == TeleporterPosition.right)
        {
            Blob blobScript = other.gameObject.GetComponent<Blob>();
            gameManager.duality = gameManager.duality + blobScript.health;
        }
        if (other.tag == "Villain" && tp == TeleporterPosition.left)
        {
            Blob blobScript = other.gameObject.GetComponent<Blob>();
            gameManager.duality = gameManager.duality - blobScript.health;
        }
    }
}
