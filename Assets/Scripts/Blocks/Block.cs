using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public enum eBlockType
{
    BlockLv0,
    BlockLv1,
    BlockLv2
}

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private List<Material> materials;
    [SerializeField] private eBlockType _blockType;
    public eBlockType BlockType => _blockType;

    [SerializeField] int _hits = 0;
    public int Hits => _hits;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UpdateBlockMaterial();
    }

    public void UpdateBlockMaterial()
    {
        if (!_meshRenderer)
        {
            return;
        }
        
        switch (_blockType)
        {
            case eBlockType.BlockLv1:
                _meshRenderer.material = materials[1];
                break;
            case eBlockType.BlockLv2:
                _meshRenderer.material = materials[2];
                break;
            default:
                break;
        }    
    }

    public void HighlightBlock(Block block)
    {
        if (block)
        {
            block.SetMaterial(materials[4]);
        }
    }

    private void SetMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
    
    public void DealDamage(int damage)
    {
        _hits -= math.clamp(damage, 0, _hits);

        if (_hits <= 0)
        {
            // Distruggi blocco
            Destroy(gameObject);
        }
        else
        {
            UpdateBlockMaterial();
        }
    }
}
