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
}
