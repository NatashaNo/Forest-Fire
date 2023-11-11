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
    public AudioSource soundWhenRefilling;

    public ParticleSystem bubblesParticle;

    public Slider waterSlider;
    public Image fillImage;
    public Color maxColor = Color.blue;
    public Color yellowColor = Color.yellow;
    public Color redColor = Color.red;
    public float yellowThreshold = 50f;
    public float redThreshold = 20f;

    public GameObject[] wells;




    // Start is called before the first frame update
    void Start()
    {
        waterSlider.maxValue = maximumWater;
        currentWater = maximumWater;
        Debug.Log("The starting health of the player is:    " + currentWater);

        currentWater = maximumWater;
        Debug.Log("The current tank is " + currentWater);

        wells = GameObject.FindGameObjectsWithTag("Well");

        for (int i = 0; i < wells.Length; i++)
        {
            wells[i].GetComponent<Well>().waterGun = this;
        }

        if (waterSlider == null)
        {
            waterSlider = GetComponent<Slider>();
        }
        if (fillImage == null)
        {
            fillImage = waterSlider.fillRect.GetComponent<Image>();
        }
        soundWhenRefilling = GetComponent<AudioSource>();

        if (waterSlider == null)
        {
            Debug.LogError("WaterGun Slider not set!");
        }


    }
    void UpdateSliderColor()
    {
        float waterSliderValue = waterSlider.value;

        if (waterSliderValue >= yellowThreshold)
        {
            fillImage.color = maxColor;
        }
        else if (waterSliderValue >= redThreshold)
        {
            fillImage.color = yellowColor;
        }
        else
        {
            fillImage.color = redColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliderColor();

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

                if (bubblesParticle.isPlaying == false)
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Collision detected");
    //    if (other.CompareTag("Well"))
    //    {
    //        soundWhenRefilling.Play();
    //        Debug.Log("Well trigger detected");
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Well"))
    //    {
    //        soundWhenRefilling.Stop();
    //    }
    //}
}


