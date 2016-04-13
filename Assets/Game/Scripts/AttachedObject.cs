using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttachedObject 
{
	public GameObject gameObject;
	public Vector3 position;
	public Vector3 rotation;
	public float offset;
	public Vector3 forward;
	public Vector2 pageVisibility;
}
