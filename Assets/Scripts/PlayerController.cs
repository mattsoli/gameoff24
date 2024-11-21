using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creazione del raggio dalla posizione del mouse
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Se il raggio colpisce un oggetto
            {
                GameObject clickedObject = hit.collider.gameObject; // Ottieni l'oggetto cliccato
                Debug.Log(clickedObject);
                // Controlla se l'oggetto ha il tag "Blocco"
                if (TryGetComponent(out Block block))
                {
                    block.DealDamage(1);
                    // Azione da eseguire se è un blocco
                    Debug.Log($"Hai cliccato su un blocco: {clickedObject.name}");
                    // Esegui altre operazioni qui
                }
            }
        }
    }
}
