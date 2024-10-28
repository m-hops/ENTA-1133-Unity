using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThroughTexture : MonoBehaviour
{
    [SerializeField] public Camera TextureCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            
        }
    }
}
