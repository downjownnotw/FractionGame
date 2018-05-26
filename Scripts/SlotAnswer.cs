using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SlotAnswer : MonoBehaviour, IDropHandler {
    public Button ButtonJawab;
    GameObject popup;

    public GameObject Wrong;
    public GameObject Answer;
    public GameObject Correct;
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        ListFraction list = gameObject.GetComponent<ListFraction>();

        if (!item)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            if(item == Answer)
            {
                Correct.SetActive(true);
            }
            else
            {
                Wrong.SetActive(true);
            }
        }
    }
}
