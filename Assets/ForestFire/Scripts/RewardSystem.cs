using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public TMP_Text counterText;
    public GameObject winCanvas;
    public static bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = Fire.treeCounter.ToString() + " / 15";

        if (!isActive)
        {
            winCanvas.SetActive(true);
        }
    }

    
}
