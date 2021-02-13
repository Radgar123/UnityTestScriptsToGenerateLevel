using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
   public static void CollectMoney(int value) 
    {
        ScoresController.numberOfMoney += value;
    }
}
