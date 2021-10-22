using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    int resourceAmount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResourceAmount(int amount)
    {
        resourceAmount = amount;
    }

    public int CollectResource()
    {
        return resourceAmount;
    }
    private void OnDestroy()
    {
        
    }
}
