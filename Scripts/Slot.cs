﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler{
	public GameObject item{
		get{
			if(transform.childCount>0){
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}
		#region IDropHandler implentation
		public void OnDrop(PointerEventData eventData){
			if(!item){
				DragHandler.itemBeingDragged.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
			}
		}
		#endregion
	
}