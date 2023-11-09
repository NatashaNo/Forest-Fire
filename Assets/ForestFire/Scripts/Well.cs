using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    public WaterGun waterGun;
    public float refillFlowPerSecond;


    // Start is called before the first frame update
    void Start()
    {
        waterGun = GameObject.FindGameObjectWithTag("Water Gun").GetComponent<WaterGun>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water Gun")
        {
            Debug.Log("Gun entered the well");
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water Gun")
        {
            Debug.Log("Gun stays in the well");
            if (waterGun.currentWater >= waterGun.maximumWater)
            {
                waterGun.currentWater = waterGun.maximumWater;
                Debug.Log("Gun is full");
            }
            else
            {
                waterGun.currentWater += refillFlowPerSecond * Time.deltaTime;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water Gun")
        {
            Debug.Log("Gun exits the well");
        }
    }
}
