using System.Collections.Generic;
using UnityEngine;

public class ProduceManager : MonoBehaviour
{
    public Dictionary<string,int> TheProduce = new Dictionary<string, int>{};
    public GlobalVariableManager theGlobalVariables;

    private void Start()
    {
        foreach(GlobalVariableManager.ProduceInfo theInfo in theGlobalVariables.TheProduceValues)
        {
            TheProduce[theInfo.Name] = 0;
        }
    }
    
    public int AddToManager(string produceType, int numToAdd)
    {
        if (TheProduce.ContainsKey(produceType))
        {
            TheProduce[produceType] += numToAdd;
            return numToAdd;
        }
        else
        {
            return -2;
        }
    }
    
    public int RemoveFromManager(string produceType, int numToRemove)
    {
        if (TheProduce.ContainsKey(produceType))
        {
            TheProduce[produceType] -= numToRemove;
            return numToRemove;
        }
        else
        {
            return -1;
        }
        
    }
    
    public int GetNumberOfProduce(string produceType)
    {
        if (TheProduce.ContainsKey(produceType))
        {
            return TheProduce[produceType];
        }
        else
        {
            return -1;
        }
    }
    
}
