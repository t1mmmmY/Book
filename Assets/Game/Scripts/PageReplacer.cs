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
//		book.onRebuild += OnRebuild;

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

//		pageBuilder.pages = textPart.pages;

		Debug.Log(pageNumber.ToString());
		book.AttachDynamicObjectToPage(book.pages[pageNumber], 0);
//		book.pages[0].obj = book.MakePageObject(book.pages[0], 0);
//		book.BuildPageMeshes(); //It is working!
//		book.pages[0].UpdateAttached(book.pageparams[0].objects[0], 0);
//		book.MakePageObject

//		book.rebuild = true;
//		book.rebuildmeshes = true;

//		book.UpdateAttached();
//		book.MakePageObject(book.pages[pageNumber], 0);
//		book.UpdateBookMT();
//		book.UpdateAttachObject(book.pages[pageNumber], book.);

//		book.pages[pageNumber].UpdateAttached();

//		Debug.Log(book.pages.Count.ToString());
//		Debug.Log(book.pageparams.Count.ToString());

	}

	void OnRebuild()
	{
		book.onRebuild -= OnRebuild;

//		book.rebuild = true;
		book.rebuildmeshes = true;
	}

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
