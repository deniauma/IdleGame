using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IdleClick : MonoBehaviour {

    public GameManager gameManager;
    private Button idleButton;
    public double gps = 0;
    public int level = 0;
    public double buyCost = 10;
    public float gpsPerLevel = 2;
    public float costNextLevel = 3;
    private bool upgradeToBuy = false;
    Dictionary<int, bool> upgrades = new Dictionary<int, bool>();

    // Use this for initialization
    void Start () {
        initUpgrades();
        idleButton = GetComponent<Button>();
        idleButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
        idleButton.GetComponentInChildren<Text>().text = getIdleButtonText();
        idleButton.interactable = isBuyOptionAvailable();
	}

    private void initUpgrades()
    {
        upgrades.Add(10, false);
        upgrades.Add(50, false);
        upgrades.Add(100, false);
    }

    private string getIdleButtonText()
    {
        int nbLvls = gameManager.getBuyNumber();
        if (nbLvls == 0)
            nbLvls = nbMaxLevelsToBuy();
        double cost = 0;
        if (nbLvls == 0)
        {
            cost = costForNextLevel();
            nbLvls = 1;
        }
        else
            cost = costForNextLevels(nbLvls);
        return "Lvl " + level + " | Next " + nbLvls + " level(s): " + cost + "G";
    }

    private bool isBuyOptionAvailable()
    {
        int nbLvls = gameManager.getBuyNumber();
        if (nbLvls == 0)
            nbLvls = nbMaxLevelsToBuy();
        if (nbLvls == 0)
            return false;
        else
        {
            double cost = costForNextLevels(nbLvls);
            if (cost <= gameManager.totalGold)
            {
                return true;
            }
            else
                return false;
        }
    }

    public void clicked()
    {
        double gpsIncrease = gps;
        int nbLvls = gameManager.getBuyNumber();
        if (nbLvls == 0)
            nbLvls = nbMaxLevelsToBuy();
        double cost = costForNextLevels(nbLvls);

        gameManager.totalGold -= cost;
        level += nbLvls;
        gps = level * gpsPerLevel;
        gpsIncrease = gps - gpsIncrease;
        gameManager.goldPerSec += gpsIncrease;
    }

    public double costForNextLevel()
    {
        if (level == 0)
            return buyCost;
        else
            return System.Math.Floor(buyCost * Mathf.Pow(costNextLevel, level+1));
    }

    private double costForLevel(int lvl)
    {
        if (lvl == 1)
            return buyCost;
        else
            return System.Math.Floor(buyCost * Mathf.Pow(costNextLevel, lvl));
    }

    public double costForNextLevels(int nb)
    {
        double total = 0;
        for (int i = level + 1; i <= level + nb; i++)
        {
            total += costForLevel(i);
        }
        return total;
    }

    public int nbMaxLevelsToBuy()
    {
        double total = 0;
        double gold = gameManager.totalGold;
        int nblvls = -1;

        int i = level + 1;
        do
        {
            nblvls++;
            if (i == 1)
                total = buyCost;
            else
                total += costForLevel(i);
            i++;
        } while (gold >= total);

        return nblvls;
    }

}
