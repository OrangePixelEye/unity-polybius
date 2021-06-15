using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolybiusScreen : Interactable
{
	[SerializeField]
	private GameObject new_room;

	protected override void OnMouseUp()
	{
		if(PolybiusManager.Instance.CanPlay) MapController.Instance.changeMap(new_room);
	}
}
