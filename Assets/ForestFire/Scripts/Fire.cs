using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public ForestFireCell.State state;
    public ForestFire3D forestFire;

    public int collisions;

    private void Start()
    {
        forestFire = GameObject.FindFirstObjectByType<ForestFire3D>();
    }

    private void OnParticleCollision(GameObject other)
    {
     

        ForestFireCell cell = transform.parent.GetComponent<ForestFireCell>();


        //  if (collisions > 0)
        // {
        if (state == ForestFireCell.State.Tree)
        {
            for (int xCount = 0; xCount < forestFire.gridSizeX; xCount++)
            {
                for (int yCount = 0; yCount < forestFire.gridSizeY; yCount++)
                { 
                    if(cell == forestFire.forestFireCells[xCount, yCount])
                    {
                        forestFire.forestFireCells[xCount, yCount].cellState = ForestFireCell.State.Tree;
                        cell.SetTree();

                    }
                }
            }


            //transform.parent.GetComponent<ForestFireCell>().SetTree();
        }


        if (state == ForestFireCell.State.Grass)
        {

            for (int xCount = 0; xCount < forestFire.gridSizeX; xCount++)
            {
                for (int yCount = 0; yCount < forestFire.gridSizeY; yCount++)
                {
                    if (cell == forestFire.forestFireCells[xCount, yCount])
                    {
                        forestFire.forestFireCells[xCount, yCount].cellState = ForestFireCell.State.Grass;
                        cell.SetGrass();

                    }
                }
            }
        }
        //}
        //else
        //{
        //    collisions++;
        //}



    }
}
