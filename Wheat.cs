using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wheat", menuName = "Wheat", order = 1)]
public class Wheat : Resource
{
   
    public override void StoreResource(Location location)
    {
        int productionYieldVariation = Mathf.CeilToInt(productionQuantity * Random.Range(.4f, -.7f));
        float foodToStore = productionQuantity * (Mathf.Log(location.totalPopulation, 21f)/.7f) + productionYieldVariation;
        Debug.Log(Mathf.Log(location.totalPopulation, 63f));
        if(foodToStore >= 0)
        {
            if (location.storedResources.ContainsKey(this))
            {
                location.storedFood += Mathf.FloorToInt(foodToStore);
                location.storedResources[this] += Mathf.FloorToInt(foodToStore);
                Debug.Log(foodToStore + this.name + " stored at " + location.name + " totaling" + location.storedResources[this] + " stored");
            }
            location.storedFood += Mathf.FloorToInt( foodToStore);
            //Debug.Log("Stored " + foodToStore);
        }
       
      
    }
 
   }
