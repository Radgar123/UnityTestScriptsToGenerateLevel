using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAbleObject : MonoBehaviour
{
    public bool isWithItem;
    public GameObject item;

    public void RevealItem() 
    {
        if (isWithItem)
            item.SetActive(true);
        else
            Debug.Log("There is no item here", this);
    }
}
