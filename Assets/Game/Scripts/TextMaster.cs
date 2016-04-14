using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TextPart
{
	public int number;
	public List<InteractivePage> pages;
}

public class TextMaster : ScriptableObject 
{
	public InteractivePage emptyPage;
	[SerializeField] TextPart[] textParts;

	public int[] GetAllPageNumbers()
	{
		int[] pageNumbers = new int[textParts.Length];
		for (int i = 0; i < pageNumbers.Length; i++)
		{
			pageNumbers[i] = textParts[i].number;
		}

		return pageNumbers;
	}

	public TextPart GetTextPart(int number)
	{
		return FindTextPart(number);
	}

	TextPart FindTextPart(int textNumber)
	{
		foreach (TextPart tp in textParts)
		{
			if (tp.number == textNumber)
			{
				return tp;
			}
		}

		Debug.LogError("Page not found!");
		return null;
	}



//	[MenuItem("Assets/Create/TextMaster")]
//	public static void CreateAsset ()
//	{
//		ScriptableObjectUtility.CreateAsset<TextMaster>();
//	}

}
