using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour {

    public GameManager gameManager;
    public Text manaText;
    private Image manaImg;

    // Use this for initialization
    void Start () {
        manaImg = GetComponent<Image>();
        
	}
	
	// Update is called once per frame
	void Update () {
        manaImg.fillAmount = gameManager.currentMana / gameManager.maxMana;
        manaText.text = "Mana: " + System.Math.Floor(gameManager.currentMana) + "/" + System.Math.Floor(gameManager.maxMana);
    }
}
