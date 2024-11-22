using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    public int currentWeapon = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creazione del raggio dalla posizione del mouse

            if (Physics.Raycast(ray, out RaycastHit hit)) // Se il raggio colpisce un oggetto
            {
                GameObject clickedObject = hit.collider.gameObject; // Ottieni l'oggetto cliccato

                if (clickedObject.TryGetComponent(out BlockChecker blockChecker))
                {
                    if (currentWeapon == 1)
                    {
                        var neighbours = blockChecker.CheckSurroundings();

                        foreach (var neighbour in neighbours)
                        {
                            if (neighbour.TryGetComponent(out Block block))
                            {
                                block.DealDamage(1);
                            }
                        }
                    }
                    else if (currentWeapon == 2)
                    {
                        if (blockChecker.TryGetComponent(out Block block))
                        {
                            block.DealDamage(2);
                        }                    
                    }
                }
            }
        }
    }
}
