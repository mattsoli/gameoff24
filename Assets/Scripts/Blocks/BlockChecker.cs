using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    float distance = 1f; // Distanza per il raycast
    public LayerMask cubeLayer; // Layer dei cubi da rilevare

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
        ((Vector3.down + Vector3.left)).normalized,
    };

    private Vector3[] depthDirections =
    {
        Vector3.forward
    };

    public List<Block> CheckDepth(int depth)
    {
        var result = new List<Block>();

        foreach (var dir in depthDirections)
        {
            // Calcoliamo la posizione da controllare
            Vector3 checkPosition = transform.position + dir * depth;

            // Controlliamo se c'è un cubo adiacente
            Collider[] hits = Physics.OverlapBox(checkPosition, Vector3.one * 0.4f, Quaternion.identity, cubeLayer);

            // Se rileviamo un oggetto
            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    Block block = hit.GetComponent<Block>(); // Prendi il componente Block
                    if (block != null && !result.Contains(block)) // Aggiungi solo se non è già nella lista
                    {
                        if (block.BlockType == eBlockType.BlockLv0)
                        {
                            // Ignora blocco bianco Livello 0
                            continue;
                        }
                       
                        result.Add(block);
                    }
                }

                Debug.DrawRay(transform.position, dir * distance, Color.green, 0.5f); // Disegna raggio verde
            }
            else
            {
                Debug.DrawRay(transform.position, dir * distance, Color.red, 0.5f); // Disegna raggio rosso
            }
        }
        return result; // Restituisci i blocchi trovati
    }
    
   public List<Block> CheckSurroundings()
   {
       var result = new List<Block>();

       foreach (var dir in directions)
       {
           // Calcoliamo la posizione da controllare
           Vector3 checkPosition = transform.position + dir * distance;

           // Controlliamo se c'è un cubo adiacente
           Collider[] hits = Physics.OverlapBox(checkPosition, Vector3.one * 0.4f, Quaternion.identity, cubeLayer);

           // Se rileviamo un oggetto
           if (hits.Length > 0)
           {
               foreach (var hit in hits)
               {
                   Block block = hit.GetComponent<Block>(); // Prendi il componente Block
                   if (block != null && !result.Contains(block)) // Aggiungi solo se non è già nella lista
                   {
                       if (block.BlockType == eBlockType.BlockLv0)
                       {
                           // Ignora blocco bianco Livello 0
                           continue;
                       }
                       
                       result.Add(block);
                   }
               }

               Debug.DrawRay(transform.position, dir * distance, Color.green, 0.5f); // Disegna raggio verde
           }
           else
           {
               Debug.DrawRay(transform.position, dir * distance, Color.red, 0.5f); // Disegna raggio rosso
           }
       }

       return result; // Restituisci i blocchi trovati
   }
}