using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableManager : MonoBehaviour
{
    public struct ProduceInfo
    {
        public string Name;
        public string TagName;
        public string PatchPrefix;
        public (int, int) PatchNumBounds;
        public Dictionary<GameObject, bool> PatchObjAndState;
        public int Price;
    };

    private ProduceInfo CreateProduceInfo(string theName, string tagName, string patchPrefix, (int, int) patchNumBounds,
        Dictionary<GameObject, bool> patchObjAndState, int price)
    {
        ProduceInfo theRetVal = new ProduceInfo();
        theRetVal.Name = theName;
        theRetVal.TagName = tagName;
        theRetVal.PatchPrefix = patchPrefix;
        theRetVal.PatchNumBounds = patchNumBounds;
        theRetVal.PatchObjAndState = patchObjAndState;
        theRetVal.Price = price;

        return theRetVal;
    }

    public List<ProduceInfo> TheProduceValues = new List<ProduceInfo>();
    
    //true if activated false if not
    public Dictionary<GameObject, bool> CarrotPatchObjAndState = new Dictionary<GameObject, bool>();
    public Dictionary<GameObject, bool> CabbagePatchObjAndState = new Dictionary<GameObject, bool>();
    public Dictionary<GameObject, bool> ApplePatchObjAndState = new Dictionary<GameObject, bool>();
    public Dictionary<GameObject, bool> TomatoPatchObjAndState = new Dictionary<GameObject, bool>();


    private void Awake()
    {
        TheProduceValues.Add(CreateProduceInfo("carrot", "Carrot", "CarrotPatch", (1, 8), CarrotPatchObjAndState, 5));
        TheProduceValues.Add(CreateProduceInfo("tomato", "Tomato", "TomatoPatch", (1, 8), TomatoPatchObjAndState, 5));
        TheProduceValues.Add(CreateProduceInfo("cabbage", "Cabbage", "CabbagePatch", (1, 8), CabbagePatchObjAndState, 5));
        TheProduceValues.Add(CreateProduceInfo("apple", "Apple", "AppleTree", (1, 8), ApplePatchObjAndState, 5));

        foreach (ProduceInfo produceType in TheProduceValues)
        {
            (int lowerBound,int upperBound) = produceType.PatchNumBounds;
            for (int i = lowerBound; i <= upperBound; i++)
            {
                string fullObjName = produceType.PatchPrefix + i.ToString();
                bool isActive = i == lowerBound;
                produceType.PatchObjAndState.Add(GameObject.Find(fullObjName),isActive);
            }

        }
    }

}
