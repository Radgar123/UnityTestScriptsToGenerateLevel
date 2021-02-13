using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScript : MonoBehaviour
{
    private const int V = 10;
    public KeyCode actionKey = KeyCode.E;
    private HideAbleObject hideSpot = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(actionKey)) 
        {
            hideSpot.RevealItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HideSpot")
            hideSpot = other.gameObject.GetComponent<HideAbleObject>();

        if(other.gameObject.tag == "Money") 
        {
            CollectableObject.CollectMoney(V);
            Destroy(other.gameObject);
            Debug.Log("error");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HideSpot")
            hideSpot = null;
    }
}
