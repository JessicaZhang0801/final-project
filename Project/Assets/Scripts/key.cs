using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : MonoBehaviour {

    public Text text;
    public static int keyNumber=1;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text ="Key:"+ keyNumber.ToString();
        
	}
}
