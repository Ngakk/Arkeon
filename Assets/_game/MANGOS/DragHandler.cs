using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngineInternal;

[RequireComponent(typeof(Image))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public LineRenderer lineRenderer;
    private bool doOnce = false;
    private float widthMultiplier = 3.5f;
    private bool entered;
    public int buttonNumber;
    public int currentNumber = 0;

    public NodeInputController nodeInputController;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1,
            new Vector3(this.transform.position.x, this.transform.position.y, 2.5f));
    }

    public void OnDrag(PointerEventData data)
    {
        if (doOnce == false)
        {
            lineRenderer.positionCount++;
            doOnce = true;
        }

        lineRenderer.SetPosition(lineRenderer.positionCount - 1,new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.5f));

        // lineRenderer.GetPosition(lineRenderer.positionCount - 1)
        var buttonWidth = this.GetComponent<RectTransform>().rect.width;
        var buttonHeight = this.GetComponent<RectTransform>().rect.height;
        
        for (int i = 0; i < nodeInputController.touchbuttons.Length; i++)
        {
            if ((currentNumber != buttonNumber) && (Input.mousePosition.x <= (nodeInputController.touchbuttons[i].transform.position.x + (buttonWidth * widthMultiplier)) && Input.mousePosition.x >= (nodeInputController.touchbuttons[i].transform.position.x - (buttonWidth) * widthMultiplier)) && (Input.mousePosition.y <= (nodeInputController.touchbuttons[i].transform.position.y + (buttonHeight * widthMultiplier)) && Input.mousePosition.y >= (nodeInputController.touchbuttons[i].transform.position.y - (buttonHeight * widthMultiplier))))
            {
                currentNumber = nodeInputController.touchbuttons[i].GetComponent<DragHandler>().buttonNumber;
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1,new Vector3(nodeInputController.touchbuttons[i].transform.position.x,nodeInputController.touchbuttons[i].transform.position.y));
            }
        }

        
    }

    private void SetDraggedPosition(PointerEventData data)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lineRenderer.positionCount = 0;
        doOnce = false;
    }
}