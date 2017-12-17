using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBuyOption : MonoBehaviour {

    private int counter = 0;
    private Button button;
    public GameManager gameManager;

    private void displayBuyText(int option)
    {
        if (counter == 0)
        {
            button.GetComponentInChildren<Text>().text = "Buy x1";
        }
        else if (counter == 1)
        {
            button.GetComponentInChildren<Text>().text = "Buy x10";
        }
        else if (counter == 2)
        {
            button.GetComponentInChildren<Text>().text = "Buy x100";
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "Buy max";
        }
    }

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        displayBuyText(gameManager.buyOption);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeBuyOption()
    {
        counter++;
        if (counter == 4)
            counter = 0;
        displayBuyText(counter);
        gameManager.buyOption = counter;
    }
}
