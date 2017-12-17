using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public double totalGold = 0;
    public double goldPerClick = 1;
    public double goldPerSec = 0;
    public float maxMana = 100;
    public float currentMana = 100;
    public float manaRegen = 1.0f;
    public Text totalGoldText;
    public Text goldPerSecText;
    public Text goldPerClickText;
    public double seconds = 0;
    public int buyOption = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(time());
	}
	    
	// Update is called once per frame
	void Update () {
        totalGoldText.text = "Total: " + System.Math.Floor(totalGold) + "G";
        goldPerSecText.text = "Gold/sec: " + goldPerSec + "G";
        goldPerClickText.text = "Gold/click: " + goldPerClick + "G";
    }

    private void timeAdd()
    {
        seconds += 1;
        totalGold += goldPerSec;
        if (currentMana + manaRegen >= maxMana)
            currentMana = maxMana;
        else
            currentMana += manaRegen;
    }

    IEnumerator time()
    {
        while (true)
        {
            timeAdd();
            yield return new WaitForSeconds(1);
        }
    }

    public int getBuyNumber()
    {
        if (buyOption == 0)
        {
            return 1;
        }
        else if (buyOption == 1)
        {
            return 10;
        }
        else if (buyOption == 2)
        {
            return 100;
        }
        else
        {
            return 0;
        }
    }
}
