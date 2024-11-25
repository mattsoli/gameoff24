using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    public int currentWeapon = 0;

    private HashSet<Block> _highlightedBlocks = new HashSet<Block>();

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creazione del raggio dalla posizione del mouse
        HashSet<Block> newHighlightedBlocks = new HashSet<Block>();

        if (Physics.Raycast(ray, out RaycastHit hit)) // Se il raggio colpisce un oggetto
        {
            GameObject clickedObject = hit.collider.gameObject; // Ottieni l'oggetto cliccato

            if (clickedObject.TryGetComponent(out BlockChecker blockChecker))
            {
                if (currentWeapon == 1) // Hammer
                {
                    var neighbours = blockChecker.CheckSurroundings();

                    foreach (var neighbour in neighbours)
                    {
                        if (neighbour.TryGetComponent(out Block block))
                        {
                            block.HighlightBlock(block);
                            newHighlightedBlocks.Add(block);

                            if (Input.GetMouseButtonDown(0))
                            {
                                block.DealDamage(1);
                            }
                        }
                    }
                }
                else if (currentWeapon == 2) // Pickaxe
                {
                    if (blockChecker.TryGetComponent(out Block block))
                    {
                        block.HighlightBlock(block);
                        newHighlightedBlocks.Add(block);

                        if (Input.GetMouseButtonDown(0))
                        {
                            block.DealDamage(2);
                        }
                    }
                }
            }
        }
        // Rimuovi l'evidenziazione dai blocchi che non sono più colpiti
        foreach (var block in _highlightedBlocks)
        {
            if (!newHighlightedBlocks.Contains(block))
            {
                block.UpdateBlock();
            }
        }
        
        // Aggiorna l'elenco dei blocchi evidenziati
        _highlightedBlocks = newHighlightedBlocks;
    }
}