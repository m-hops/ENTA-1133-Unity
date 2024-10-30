using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class ClickThroughTexture : MonoBehaviour
{
    public Camera RenderTextureCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            //Debug.Log("click");

            if (Physics.Raycast(ray, out hit))
            {
                var localPoint = hit.textureCoord;
                Ray portalRay = RenderTextureCamera.ScreenPointToRay(new Vector2(localPoint.x * RenderTextureCamera.pixelWidth, localPoint.y * RenderTextureCamera.pixelHeight));
                RaycastHit portalHit;

                if (Physics.Raycast(portalRay, out portalHit))
                {
                    Debug.Log("recast");
                    var trigger = portalHit.collider.gameObject.GetComponent<EventTrigger>();
                    trigger?.OnPointerClick(default);

                }
            }
        }

    }
}