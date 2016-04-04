using UnityEngine;
using System.Collections;

public class InteractivePage : MonoBehaviour 
{
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
}
