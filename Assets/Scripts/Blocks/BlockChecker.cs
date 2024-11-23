using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    float distance = 1.5f; // Distanza per il raycast
    public LayerMask cubeLayer; // Layer dei cubi da rilevare

    public List<Block> CheckSurroundings()
    {
        var result = new List<Block>();

        Vector3[] directions =
        {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right,
            // Diagonali verso destra
            (Vector3.up + Vector3.right).normalized,
            (Vector3.down + Vector3.right).normalized,
            // Diagonali verso sinistra
            (Vector3.up + Vector3.left).normalized,
            (Vector3.down + Vector3.left).normalized,
        };

        foreach (var dir in directions)
        {
            Debug.DrawLine(transform.position, transform.position + dir.normalized * distance, Color.blue, .25f);

            if (Physics.Raycast(transform.position, dir.normalized, out var hit, distance, cubeLayer))
            {
                if (!result.Contains(hit.transform.GetComponent<Block>()))
                {
                    Debug.Log(
                        $"{gameObject.name} ha rilevato in direzione {dir} a distanza {hit.distance} {hit.transform.name}");
                    result.Add(hit.transform.GetComponent<Block>());
                }
            }
        }

        if (!result.Contains(gameObject.GetComponent<Block>())) // aggiungo il blocco cliccato
        {
            result.Add(gameObject.GetComponent<Block>());
        }

        return result;
    }
}