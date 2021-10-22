using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ResourceType
{
    None,
    Tree,
}

public class Resource : MonoBehaviour
{
    public ResourceType resourceType;
    int resourceAmount = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GatherResource(int amount)
    {
        if(amount < resourceAmount)
        {
            resourceAmount -= amount;
            return amount;
        }
        else
        {
            int tempResource = resourceAmount;
            resourceAmount = 0;
            return tempResource;
        }
    }

    public void DropResource(int amount)
    {

    }

}
