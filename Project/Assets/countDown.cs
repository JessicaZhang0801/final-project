using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class countDown : MonoBehaviour {

    public static int CountDown = 75;
    public Text countDownText;

    // Use this for initialization
    void Start () {
        StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update () {
        countDownText.text = ("Timer: " + CountDown);
        if(CountDown<=0)
        {
            StopCoroutine("LoseTime");
            countDownText.text = "TIMES UP!";
            
        }
	}

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            CountDown--;
        }
    }
    
}
