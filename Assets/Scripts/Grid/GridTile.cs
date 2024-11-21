using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eTileType
{
    Empty,
    White,
    Yellow,
    Red
}
public class GridTile : MonoBehaviour
{
    [SerializeField] private Material _empty, _white, _yellow, _red;
    [SerializeField] private MeshRenderer _meshRenderer;

    public void Init(eTileType type)
    {
        switch (type)
        {
            case eTileType.White:
                _meshRenderer.material = _white;
                break;
            case eTileType.Yellow:
                _meshRenderer.material = _yellow;
                break;
            case eTileType.Red:
                _meshRenderer.material = _red;
                break;
            default:
                _meshRenderer.material = _empty;
                break;
        }
    }
}
