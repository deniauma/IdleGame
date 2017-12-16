using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickGoldSpawn : MonoBehaviour {

    private Text goldText;
    public float lifetime = 1;

    void Awake()
    {
        goldText = GetComponent<Text>();
        Destroy(goldText, lifetime);
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
