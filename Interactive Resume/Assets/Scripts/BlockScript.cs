using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    Component[] rbs;
    Component[] bcs;

    public float hitForceUp;
    public float hitForceUpB;
    public float hitForceDown;
    public float hitForce;

    CircleCollider2D cc;

    Transform boxZero;
    Rigidbody2D boxZeroRB;

    Transform boxOne;
    Rigidbody2D boxOneRB;

    Transform boxTwo;
    Rigidbody2D boxTwoRB;

    Transform boxThree;
    Rigidbody2D boxThreeRB;

    Transform boxFive;
    Rigidbody2D boxFiveRB;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        rbs = GetComponentsInChildren<Rigidbody2D>();
        bcs = GetComponentsInChildren<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();

        boxZero = transform.Find("block_0");
        boxZeroRB = boxZero.GetComponent<Rigidbody2D>();

        boxOne = transform.Find("block_1");
        boxOneRB = boxOne.GetComponent<Rigidbody2D>();

        boxTwo = transform.Find("block_2");
        boxTwoRB = boxTwo.GetComponent<Rigidbody2D>();

        boxThree = transform.Find("block_3");
        boxThreeRB = boxThree.GetComponent<Rigidbody2D>();

        boxFive = transform.Find("block_5");
        boxFiveRB = boxFive.GetComponent<Rigidbody2D>();

        if (other.gameObject.CompareTag("Player"))
        {
            cc.enabled = false;

            foreach (Rigidbody2D rb in rbs)
                rb.gravityScale = 3;

            foreach (BoxCollider2D bc in bcs)
                bc.isTrigger = false;

            foreach (Rigidbody2D rb in rbs)
                rb.AddForce(transform.up * hitForce);

            boxZeroRB.AddForce(-transform.right * hitForceUp);

            boxOneRB.AddForce(transform.right * hitForceUpB);

            boxTwoRB.AddForce(transform.right * hitForceUp);

            boxThreeRB.AddForce(-transform.right * hitForceDown);

            boxFiveRB.AddForce(transform.right * hitForceDown);

            foreach (Rigidbody2D rb in rbs)
                Destroy(gameObject, 5);
        }
    }

    void Update()
    {
        
    }
}