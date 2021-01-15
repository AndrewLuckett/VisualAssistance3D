using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_Vanishable : MonoBehaviour, TriggerableInterface {
    /**
    * Game object Attribute - Vanishable
    * Can be used for rudimentary doors
    **/

    public TriggerResponses trigger() {
        gameObject.SetActive(false);
        Destroy(gameObject);
        return TriggerResponses.died;
    }
}