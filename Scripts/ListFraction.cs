using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListFraction : MonoBehaviour, IHasChanged {
    public Button ButtonJawab;

    [SerializeField] Transform slots;
    [SerializeField] Text FractionText;
    public int num = 2;

	// Use this for initialization
	void Start () {
        HasChanged();
	}

	public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" ");
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<SlotAnswer>().item;
            if (item)
            {
                builder.Append(item.name);
                builder.Append(" ");
            }
        }
        FractionText.text = builder.ToString();
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}