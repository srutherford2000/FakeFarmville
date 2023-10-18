using System.Collections.Generic;
using UnityEngine;

public class NewFieldTrigger : MonoBehaviour
{
    public CapsuleCollider theCharacterCapsuleCollider;
    public GlobalVariableManager theGlobalVariables;
    public MoneyManger theMoneyManager;
    public string theProduceType;
    public int newFieldPrice;
    private Dictionary<GameObject, bool> _thePatch;
    
    private void RefreshActivateForPatches()
    {
        foreach (KeyValuePair<GameObject, bool> pairs in _thePatch)
        {   
            GameObject theField = pairs.Key;
            bool activeStatus = pairs.Value;
            theField.SetActive(activeStatus);
        }
    }
    
    private void ChangeNextBoolInDict()
    {
        foreach (KeyValuePair<GameObject,bool> pairs in _thePatch)
        {
            if (!pairs.Value)
            {
                _thePatch[pairs.Key] = true;
                return;
            }
        }
    }
    
    private void Start()
    {
        foreach (GlobalVariableManager.ProduceInfo infoStruct in theGlobalVariables.TheProduceValues)
        {
            if (infoStruct.Name == theProduceType)
            {
                _thePatch = infoStruct.PatchObjAndState;
                break;
            }
        }
        RefreshActivateForPatches();

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other == theCharacterCapsuleCollider) && (theMoneyManager.HasEnoughMoney(newFieldPrice)))
        {
            //update the field to active 
            ChangeNextBoolInDict();
            
            //refresh fields to its rendered
            RefreshActivateForPatches();
            
            //remove the money 
            theMoneyManager.RemoveMoney(newFieldPrice);
        }
    }
}
