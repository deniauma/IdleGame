﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    public GameManager gameManager;

    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void clicked()
    {
        gameManager.totalGold += gameManager.goldPerClick;
    }
}
