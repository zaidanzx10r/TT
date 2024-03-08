using UnityEngine;
using System.Collections.Generic;
using Tower_Related;

public class TowerIDManager : MonoBehaviour
{
    // Static reference to the TowerIDManager instance
    private static TowerIDManager instance;

    // Counter to generate unique tower IDs
    private int towerIDCounter = 1;

    // Dictionary to store tower IDs and their corresponding towers
    private Dictionary<int, Tower> towersByID = new Dictionary<int, Tower>();

    private PlayerHealth playerHealth;

    // Method to get the TowerIDManager instance
    public static TowerIDManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TowerIDManager>();
                
                if (instance == null)
                {
                    GameObject obj = new GameObject("TowerIDManager");
                    instance = obj.AddComponent<TowerIDManager>();
                }
            }
            return instance;
        }
    }

    public int GenerateUniqueTowerID()
    {
        int id = towerIDCounter;
        towerIDCounter++;
        return id;
    }

    public void RegisterTower(int towerID, Tower tower)
    {
        if (!towersByID.ContainsKey(towerID))
        {
            towersByID.Add(towerID, tower);
        }
        else
        {
            Debug.LogError("Tower with ID " + towerID + " is already registered.");
        }
    }

    public void UnregisterTower(int towerID)
    {
        if (towersByID.ContainsKey(towerID))
        {
            towersByID.Remove(towerID);
        }
        else
        {
            Debug.LogError("Tower with ID " + towerID + " is not registered.");
        }
    }

    public Tower GetTowerByID(int towerID)
    {
        if (towersByID.ContainsKey(towerID))
        {
            return towersByID[towerID];
        }
        else
        {
            Debug.LogError("Tower with ID " + towerID + " is not registered.");
            return null;
        }
    }
    
    public void PrintTowerDictionary()
    {
        foreach (var pair in towersByID)
        {
            Debug.Log("Tower ID: " + pair.Key + ", Tower: " + pair.Value.name);
        }
    }

    private void switchAttack()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        
        if (playerHealth.healthCount <= 0)
        {
            switchAttack();
            Debug.Log("Player has Died");
        }
    }
    

}
