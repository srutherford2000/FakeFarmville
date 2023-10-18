using UnityEngine;

public class MoneyManger : MonoBehaviour
{
    public int theMoney;

    public void AddMoney(int amountToAdd)
    {
        //add money
        theMoney += amountToAdd;
    }

    public void RemoveMoney(int amountToRemove)
    {
        //remove money
        theMoney -= amountToRemove;
    }

    public bool HasEnoughMoney(int potentialCost)
    {
        return potentialCost <= theMoney;
    }
}
