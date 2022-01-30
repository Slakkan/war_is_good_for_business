using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    Animator animator;
    float speed = 0.5f;
    float turnSpeed = 0.2f;

    public Item equippedArmor;
    public Item equippedWeapon;

    Vector3 leftPortalPosition = new Vector3(-25, -9.5f, 0);
    Vector3 rightPortalPosition = new Vector3(25, -9.5f, 0);

    public float health = 1;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        goToShop();
    }

    void Update()
    {

    }

    private void goToBattle()
    {
        if(gameObject.tag == "Hero")
        {
            moveTo(rightPortalPosition);
        }
        if (gameObject.tag == "Villain")
        {
            moveTo(leftPortalPosition);
        }
    }

    private void goToShop()
    {
        if(gameObject.tag == "Hero")
        {
            moveTo(leftPortalPosition);
        }
        if(gameObject.tag == "Villain")
        {
            moveTo(rightPortalPosition);
        }
    }

    public void moveTo(Vector3 destination)
    {
        StartCoroutine(SmoothLerp(destination));
    }
    private IEnumerator SmoothLerp(Vector3 destination)
    {
        Vector3 startingPosition = gameObject.transform.position;
        Quaternion startingAngle = gameObject.transform.rotation;
        Quaternion finalAngle = Quaternion.LookRotation(destination - startingPosition);
        float r = 0;

        while (r <= 1f)
        {
            r += turnSpeed * Time.fixedDeltaTime;
            gameObject.transform.rotation = Quaternion.Lerp(startingAngle, finalAngle, r);

            Debug.Log("ROTATING");

            yield return null;
        }

        animator.SetBool("isWalking", true);
        float step = (speed / (startingPosition - destination).magnitude) * Time.fixedDeltaTime;
        float t = 0;

        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            gameObject.transform.position = Vector3.Lerp(startingPosition, destination, t);

            yield return null;
        }
        gameObject.transform.position = destination;
        animator.SetBool("isWalking", false);
    }


}
