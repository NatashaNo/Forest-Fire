using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WaterGun : MonoBehaviour

{
    public InputActionReference waterReference;
    public float maximumWater;
    public float currentWater;
    public float flowAmountPerSecond;
    public AudioSource soundWhenPressingTheTrigger;
    public Slider waterSlider;
    public ParticleSystem bubblesParticle;
    //public AudioSource soundWhenRefilling;



    // Start is called before the first frame update
    void Start()
    {
        
        if (waterSlider == null)
        {
            Debug.LogError("WaterGun Slider not set!");
        }

        waterSlider.maxValue = maximumWater;
        currentWater = maximumWater;
        Debug.Log("The starting health of the player is:    " + currentWater);


        currentWater = maximumWater;
        Debug.Log  ("The current tank is " + currentWater);

    }

    // Update is called once per frame
    void Update()
    {
        waterSlider.value = currentWater;   

        if (waterReference.action.IsPressed())
        {
            Debug.Log("Trigger Pressed");

            if (currentWater > 0)
            {
                if (soundWhenPressingTheTrigger.isPlaying == false)
                {
                    soundWhenPressingTheTrigger.Play();
                    Debug.Log("Trigger pressed, Sound is on");
                }
                currentWater -= flowAmountPerSecond * Time.deltaTime;
                Debug.Log("Shooting Water!");

                if(bubblesParticle.isPlaying == false)
                {
                    bubblesParticle.Play();
                    Debug.Log("Trigger pressed, bubbles on");
                }
            }
            else
            {
                soundWhenPressingTheTrigger.Stop();
                Debug.Log("Trigger released, sound is off");


                Debug.Log("No Water!");
                if (currentWater < 0)
                {
                    currentWater = 0;
                    StopBubbles();
                }
               
            }
        }
        else
        {
            StopBubbles();
            
        }
    }

    private void StopBubbles()
    {
        if (bubblesParticle.isPlaying == true)
        {
            bubblesParticle.Stop();
            Debug.Log("Trigger released, bubbles off");
        }

        if (soundWhenPressingTheTrigger.isPlaying == true)
        {
            soundWhenPressingTheTrigger.Stop();
            Debug.Log("Trigger released, sound is off");
        }
    }

}


  