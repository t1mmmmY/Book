using UnityEngine;
using System.Collections;

enum PageAction
{
	NextPage,
	PrevPage,
	Nothing
}

//[RequireComponent(typeof(BoxCollider))]
public class InteractivePage : MonoBehaviour
{
	[SerializeField] PageAction pageAction;
	[SerializeField] AttachedObject[] attachedObjects;

	public AttachedObject[] GetAttachedObjects()
	{
		return attachedObjects;
	}

	public void Init(MegaBookBuilder book)
	{
		
	}

	public void DestroyPage()
	{
		foreach (AttachedObject attachment in attachedObjects)
		{
			Destroy(attachment.gameObject);
		}
		Destroy(this.gameObject);
	}

//	public void OnPush()
//	{
//	}
//
//	public void OnStay()
//	{
//	}
//
//	public void OnRelease()
//	{
//		switch (pageAction)
//		{
//			case PageAction.NextPage:
//				BookController.Instance.NextPage();
//				break;
//			case PageAction.PrevPage:
//				BookController.Instance.PrevPage();
//				break;
//			case PageAction.Nothing:
//				break;
//		}
//	}
}
