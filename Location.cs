using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Location : MonoBehaviour
{
    [SerializeField]
    Sprite sprite;

    [SerializeField]
    public int storedFood;

    [SerializeField]
    public int money;
    [SerializeField]
    public int totalPopulation;
    [SerializeField]
    protected int starvingPopulation;

    protected int daysTillStarve = 30;

    [SerializeField]
    int startPopulation;

    [SerializeField]
    protected GameObject[] npcs;

    [SerializeField]
    GameObject owner;

    [SerializeField]
    protected Location[] childLocations;

    [SerializeField]
    Location parentLocation;

    public Dictionary<Resource, int> storedResources;

 


    // Start is called before the first frame update
    void Start()
    {

        List<Resource> resources = FindObjectOfType<ResourceManager>().resources;
        storedResources = new Dictionary<Resource, int>();
        foreach (Resource resource in resources)
        {
            storedResources.Add(resource, 0);
            Debug.Log("added " + resource.name);
        }
        FindObjectOfType<TimeController>().dayIncrementEvent += ConsumeFood;
        totalPopulation = startPopulation;
    }

    protected virtual void TradeGoods()
    {
      
    }
    protected virtual void ConsumeFood(int amount)
    {
        if (storedFood >= totalPopulation)
        {
            foreach(KeyValuePair<Resource,int> kvp in storedResources)
            {
                if(kvp.Key == Wheat)
                {

                }
            }
            storedResources -= totalPopulation;
            starvingPopulation = 0;
            daysTillStarve = 0;
        }
        else if(storedFood < totalPopulation && storedFood > 0)
        {
            starvingPopulation = totalPopulation - storedFood;
            storedFood -= storedFood;
        }
        else if( storedFood == 0)
        {
            starvingPopulation = totalPopulation;
        }
        if(starvingPopulation > 0)
        {
            daysTillStarve--;
            if(daysTillStarve <= 0)
            {
                totalPopulation -= starvingPopulation;
                starvingPopulation = 0;
                daysTillStarve = 30;
            }
        }
        if(storedFood < 0)
        {
            storedFood = 0;
        }

    }
    private void OnDisable()
    {

        //FindObjectOfType<TimeController>().dayIncrementEvent -= ConsumeFood;
    }
}
