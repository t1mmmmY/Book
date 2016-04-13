using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PageFlip : MonoBehaviour, InteractiveObject
{
	[SerializeField] PageAction pageAction;

	public void OnPush()
	{
	}

	public void OnStay()
	{
	}

	public void OnRelease()
	{
		switch (pageAction)
		{
			case PageAction.NextPage:
				BookController.Instance.NextPage();
				break;
			case PageAction.PrevPage:
				BookController.Instance.PrevPage();
				break;
			case PageAction.Nothing:
				break;
		}
	}
}
