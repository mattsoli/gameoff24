using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GridTile _tilePrefab;

    private Transform _cam;

    private void Awake()
    {
        _cam = Camera.main.transform;
    }

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0);
                eTileType type = isOffset ? eTileType.Red : eTileType.Yellow;
                spawnedTile.Init(type);
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10); // Centro la camera alla Griglia
    }
}