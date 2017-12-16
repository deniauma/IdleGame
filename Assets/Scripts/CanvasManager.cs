using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour, IPointerClickHandler {

    public GameManager gameManager;
    public Text goldOnClickText;
    private Canvas gameCanvas;

    // Use this for initialization
    void Start () {
        gameCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        gameManager.totalGold += gameManager.goldPerClick;
        displayGoldOnClick(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void displayGoldOnClick(float x, float y)
    {
        Text newText = Instantiate(goldOnClickText);
        newText.transform.SetParent(gameCanvas.transform);
        newText.rectTransform.position = new Vector2(x+30, y);
    }
    
}
