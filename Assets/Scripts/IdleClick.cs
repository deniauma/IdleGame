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

    // Use this for initialization
    void Start () {
        idleButton = GetComponent<Button>();
        idleButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
        idleButton.GetComponentInChildren<Text>().text = "Lvl " + level + " | Next level: " + costForNextLevel() + "G";

        if (gameManager.totalGold >= costForNextLevel())
        {
            idleButton.interactable = true;
        }
        else
        {
            idleButton.interactable = false;
        }
	}

    private string getIdleButtonText()
    {
        int nbLvls = gameManager.getBuyNumber();
        if(nbLvls > 0)
        {
            double cost = costForNextLevels(gameManager.getBuyNumber());
            return "Lvl " + level + " | Next " + nbLvls + " level(s): " + costForNextLevels(nbLvls) + "G";
        }
        else
        {

        }
    }

    public void clicked()
    {
        double gpsIncrease = gps;
        gameManager.totalGold -= costForNextLevel();
        level++;
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
        if (lvl == 0)
            return buyCost;
        else
            return System.Math.Floor(buyCost * Mathf.Pow(costNextLevel, lvl));
    }

    public double costForNextLevels(int nb)
    {
        double total = 0;
        if (level == 0)
            total = buyCost;
        for (int i = level + 1; i <= level + nb; i++)
        {
            total += costForLevel(i);
        }
        return total;
    }

    public double costForMaxLevel()
    {
        double total = 0;
        if (level == 0)
            total = buyCost;
        
        return total;
    }

}
