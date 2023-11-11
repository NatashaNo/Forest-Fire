using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    public WaterGun waterGun;
    public float refillFlowPerSecond;
    public AudioSource soundWhenRefilling;


    // Start is called before the first frame update
    void Start()
    {
        //waterGun = GameObject.FindGameObjectWithTag("UpdatedWaterGun").GetComponent<WaterGun>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (waterGun == null)
        //{
        //    Debug.Log("Looking for Water Gun...");

        //    waterGun = GameObject.FindGameObjectWithTag("UpdatedWaterGun").GetComponent<WaterGun>();
        //}
        //else
        //{
        //    Debug.Log("Water Gun found!!!");
        //    return;
        //}
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UpdatedWaterGun")
        {
            Debug.Log("Gun entered the well");
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "UpdatedWaterGun")
        {

            Debug.Log("Well trigger detected");
            Debug.Log("Gun stays in the well");
            if (waterGun.currentWater >= waterGun.maximumWater)
            {
                soundWhenRefilling.Stop();

                waterGun.currentWater = waterGun.maximumWater;
                Debug.Log("Gun is full");
            }
            else
            {

                if (soundWhenRefilling.isPlaying == false)
                {
                    soundWhenRefilling.Play();
                }

                waterGun.currentWater += refillFlowPerSecond * Time.deltaTime;

            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "UpdatedWaterGun")
        {
            if (soundWhenRefilling.isPlaying == true)
            {
                soundWhenRefilling.Stop();
            }
            Debug.Log("Gun exits the well");
        }
    }
}
