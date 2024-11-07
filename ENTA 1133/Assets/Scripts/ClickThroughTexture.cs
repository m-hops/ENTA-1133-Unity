using UnityEngine;
using UnityEngine.EventSystems;

public class ClickThroughTexture : MonoBehaviour
{
    public Camera RenderTextureCamera;
    public EventTrigger CurrentHoverEventTrigger;
    void Update()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            var localPoint = hit.textureCoord;
            Ray portalRay = RenderTextureCamera.ScreenPointToRay(new Vector2(localPoint.x * RenderTextureCamera.pixelWidth, localPoint.y * RenderTextureCamera.pixelHeight));
            RaycastHit portalHit;

            if (Physics.Raycast(portalRay, out portalHit))
            {
                var trigger = portalHit.collider.gameObject.GetComponent<EventTrigger>();
                if(trigger == null)
                {
                    if (CurrentHoverEventTrigger != null)
                    {
                        CurrentHoverEventTrigger.OnPointerExit(default);
                    }
                    CurrentHoverEventTrigger = null;

                } else
                {
                    if(CurrentHoverEventTrigger != trigger)
                    {
                        if (CurrentHoverEventTrigger != null)
                        {
                            CurrentHoverEventTrigger.OnPointerExit(default);
                        }
                        trigger.OnPointerEnter(default);
                        CurrentHoverEventTrigger = trigger;
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        trigger?.OnPointerClick(default);
                    }

                }
            }
            else
            {
                if (CurrentHoverEventTrigger != null)
                {
                    CurrentHoverEventTrigger.OnPointerExit(default);
                }
                CurrentHoverEventTrigger = null;
            }
        }





        

    }
}