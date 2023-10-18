using TMPro;
using UnityEngine;

public class BoxTextManager : MonoBehaviour
{
    public string boxProduceType;
    public TMP_Text theBoxCountText;
    public ProduceManager theBoxProduceManager;

    // Update is called once per frame
    void Update()
    {
        theBoxCountText.text = theBoxProduceManager.TheProduce[boxProduceType].ToString();
    }
}
