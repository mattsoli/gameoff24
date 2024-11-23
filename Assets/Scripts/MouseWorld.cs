using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseWorld : MonoSingleton<MouseWorld>
{  
    [SerializeField]
    private LayerMask mousePlaneLayer;

    void Update()
    {
        transform.position = GetPosition();
    }
    
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, Instance.mousePlaneLayer);

        return hit.point;
    }
}
