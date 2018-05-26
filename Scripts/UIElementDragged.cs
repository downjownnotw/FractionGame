using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragged : MonoBehaviour {
    public const string DRAGGABLE_TAG = "UIDraggabbe";
    private bool dragging = false;
    private Vector3 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0))
        {
            objectToDrag = GetObjectUnderMouse().transform;
            print("object drag = " + objectToDrag.name);

            if (objectToDrag != null)
            {
                dragging = true;
                objectToDrag.SetAsLastSibling();
                originalPosition = objectToDrag.position;
            }
        }
        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            var objectToReplace = GetObjectUnderMouse().transform;
            try
            {
                print("Object Replace =" + objectToReplace.name);
            }
            catch
            {
                objectToDrag = null;
            }
            if (objectToDrag != null)
            {
                if(objectToDrag.GetComponent<Identity>().jenis == objectToReplace.GetComponent < Identity>().jenis)
                {
                    objectToDrag.position = objectToReplace.position;
                    objectToReplace.position = originalPosition;
                }
                else
                {
                    objectToDrag.position = originalPosition;
                }
            }
        }
	}

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, hitObjects);
        if (hitObjects.Count <= 0)
            return null;

        GameObject gof = null;
        int i = 0;

        foreach(RaycastResult go in hitObjects)
        {
            i++;
            if(go.gameObject.tag == "UIDraggable")
            {
                gof = go.gameObject;
            }
        }
        return gof;
    }
}
