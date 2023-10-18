using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GlobalVariableManager theGlobalVariables;
    public ProduceManager theBoxProduceManager;
    public MoneyManger theMoneyManager;
    public MoveTruckManager theTruckManager;
    public float theDifficultyMultiplier;

    private Dictionary<string, int> _produceToNumFields = new Dictionary<string, int>();
    public Dictionary<string, int> TheCurrentTask = new Dictionary<string, int>();

    // Update is called once per frame
    void Update()
    {
        bool hasNoTask = HasNoTask();
        if (hasNoTask && (theTruckManager.currentState == 1))
        {
            GenerateNewTask();
            theTruckManager.currentState = 2;
        }
        else if ((!hasNoTask) && CheckTaskCompleted())
        {
            //remove the items from the box
            foreach (KeyValuePair<string, int> pairs in TheCurrentTask)
            {
                theBoxProduceManager.RemoveFromManager(pairs.Key, pairs.Value);
                for (int i = 0; i < pairs.Value; i++)
                {
                    Destroy(GameObject.Find(pairs.Key + "_rigid(Clone)"));
                }
            }
            
            //calculate amount earned and add it to the money manager
            int totalEarned = CalculateTaskTotal();
            theMoneyManager.AddMoney(totalEarned);

            //clear the task
            TheCurrentTask = new Dictionary<string, int>(); //reset the old task
            
            //set the truck task completed to true
            theTruckManager.currentState = 3;
        }
    }

    private void GenerateNewTask()
    {
        GetNumberOfActiveFields();
        foreach (KeyValuePair<string, int> pairs in _produceToNumFields)
        {
            TheCurrentTask.Add(pairs.Key, (int) Random.Range(0f, pairs.Value * theDifficultyMultiplier));
        }
    }

    private bool CheckTaskCompleted()
    {
        bool taskComplete = true;
        foreach (KeyValuePair<string, int> pairs in TheCurrentTask)
        {
            if (TheCurrentTask.ContainsKey(pairs.Key))
            {
                taskComplete &= theBoxProduceManager.GetNumberOfProduce(pairs.Key) >= pairs.Value;
            }
        }
        return taskComplete;
    }

    private void GetNumberOfActiveFields()
    {
        _produceToNumFields = new Dictionary<string, int>();
        foreach (GlobalVariableManager.ProduceInfo produceInfo in theGlobalVariables.TheProduceValues)
        {
            int numActive = 0;
            foreach (bool isActive in produceInfo.PatchObjAndState.Values)
            {
                if (isActive) numActive++;
            }
            _produceToNumFields.Add(produceInfo.Name, numActive);
            
        }
    }

    private bool HasNoTask()
    {
        return TheCurrentTask.Count == 0;
    }

    private int CalculateTaskTotal()
    {
        int totalScore = 0;
        foreach (GlobalVariableManager.ProduceInfo theInfo in theGlobalVariables.TheProduceValues)
        {
            totalScore += TheCurrentTask[theInfo.Name] * theInfo.Price;
        }

        return totalScore;
    }
}
