using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private List<Material> materials;

    [SerializeField] int _hits = 0;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UpdateBlock();
    }

    public void UpdateBlock()
    {
        switch (_hits)
        {
            case 0:
                _meshRenderer.material = materials[0];
                break;
            case 1:
                _meshRenderer.material = materials[1];
                break;
            case 2:
                _meshRenderer.material = materials[2];
                break;
            default:
                break;
        }    
    }

    public void HighlightBlock(Block block)
    {
        block.SetMaterial(materials[4]);
    }

    private void SetMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
    
    public void DealDamage(int damage)
    {
        _hits -= math.clamp(damage, 0, _hits);
        UpdateBlock();
    }
}
