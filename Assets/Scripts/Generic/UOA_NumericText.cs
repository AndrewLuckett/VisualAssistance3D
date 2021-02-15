using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UOA_NumericText : MonoBehaviour {
    /**
     * UI object attribute - Numeric Text
     * Utility to ease setting text objects to numeric values
    **/

    public string strFormat = "0.00";
    Text t;

    void Start() {
        t = GetComponent<Text>();
    }

    public void UpdateText(float value) {
        if(t == null) { //I cba to force the start order anytime I used this
            Start();
        }

        t.text = value.ToString(strFormat);
    }

    public void UpdateTextPercent(float value) {
        if(t == null) { //I cba to force the start order anytime I used this
            Start();
        }

        t.text = value.ToString(strFormat) + "%";
    }
}
