using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision detected!");
        ForestFireCell cell = GetComponentInParent<ForestFireCell>();
        cell.cellFuel = 0;
        cell.SetBurnt();
    }


}
