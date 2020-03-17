using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : ScriptableObject
{
    //number of days needed to produce resource
    [SerializeField]
    public int productionRate;

    //amount gathered
    [SerializeField]
    public int productionQuantity = 10;
    public virtual void StoreResource(Location location)
    {
        Debug.Log("Storing " + productionQuantity + " At " + location.name);
    }
}
