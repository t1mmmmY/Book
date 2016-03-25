using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageReplacer : MonoBehaviour 
{
	[SerializeField] MegaBookBuilder book;
	[SerializeField] MBComplexPage pageBuilder;
	[SerializeField] TextMaster textMaster;


	float scaler = 0.05f;

	void Start()
	{
		int numPages = book.NumPages;
		scaler = numPages / 1000.0f;
	}

	public void ReplacePage(int pageNumber, int textNumber)
	{
		TextPart textPart = textMaster.GetTextPart(textNumber);

		//Delete old pages
		List<GameObject> pages = pageBuilder.pages;
		foreach (GameObject go in pages)
		{
			Destroy(go);
		}
		pageBuilder.pages = new List<GameObject>();

		//Create and assign new pages
		foreach (GameObject page in textPart.pages)
		{
			GameObject go = GameObject.Instantiate<GameObject>(page);
			pageBuilder.pages.Add(go);
		}


		Debug.Log(pageNumber.ToString());

		for (int i = 0; i < pageBuilder.pages.Count; i++)
		{
			book.AttachDynamicObjectToPage(book.pages[pageNumber + i], i);
		}

	}

//	void OnRebuild()
//	{
//		book.onRebuild -= OnRebuild;
//
//		book.rebuildmeshes = true;
//	}

	int GetPageNumber(int textNumber)
	{
		return Mathf.RoundToInt(textNumber * scaler);
	}

	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		{
			if (GUILayout.Button("312"))
			{
				ReplacePage(GetPageNumber(312), 312);
			}
			if (GUILayout.Button("0"))
			{
				ReplacePage(GetPageNumber(0), 0);
			}
			if (GUILayout.Button("28"))
			{
				ReplacePage(GetPageNumber(28), 28);
			}

		} GUILayout.EndHorizontal();
	}

}
