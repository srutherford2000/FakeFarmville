using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextManager : MonoBehaviour
{
    public GlobalVariableManager theGlobalVariables;
    public TMP_Text theUserCarryingText;
    public TMP_Text theTaskText;
    public TMP_Text theMoneyText;
    public ProduceManager thePlayerProduceManager;
    public TaskManager theTaskManager;
    public MoneyManger theMoneyManager;

    private void Update()
    {
        UpdateTaskText(theTaskManager.TheCurrentTask);
        UpdatePlayerCarryingText(thePlayerProduceManager.TheProduce);
        UpdateMoneyText(theMoneyManager.theMoney);
    }

    private void UpdatePlayerCarryingText(Dictionary<string, int> playerProduceDict)
    {
        string newHoldingVal = "User Holding:\n";

        foreach (KeyValuePair<string, int> pair in playerProduceDict)
        {
            newHoldingVal += pair.Key+"s:" + pair.Value.ToString() + "\n";

        }
        
        theUserCarryingText.text = newHoldingVal;
    }
    
    private void UpdateTaskText(Dictionary<string,int>theCounts)
    {
        string newTaskText = "Task:\n";

        foreach (KeyValuePair<string,int> pairs in theCounts)
        {
            newTaskText += pairs.Key+":" + pairs.Value.ToString() + "\n";
        }
        
        theTaskText.text = newTaskText;
    }

    private void UpdateMoneyText(int currentMoney)
    {
        theMoneyText.text = "Money: " + currentMoney.ToString();
    }
    
}
