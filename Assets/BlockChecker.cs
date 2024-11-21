using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    public float distance = 1.0f; // Distanza per il raycast
    public LayerMask cubeLayer;  // Layer dei cubi da rilevare

    void CheckSurroundings()
    {
        Vector3[] directions = {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right,
            Vector3.forward,
            Vector3.back,
            Vector3.up + Vector3.forward, // Diagonale
            Vector3.up + Vector3.right    // Diagonale
        };

        foreach (var dir in directions)
        {
            if (Physics.Raycast(transform.position, dir.normalized, out RaycastHit hit, distance, cubeLayer))
            {
                Debug.Log($"{gameObject.name} ha rilevato in direzione {dir} a distanza {hit.distance} {hit.transform.name}");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Premi SPAZIO per controllare
        {
            CheckSurroundings();
        }
    }
}