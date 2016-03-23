using UnityEngine;
using System.Collections;

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
		pageBuilder.pages = textPart.pages;

		Debug.Log(pageNumber.ToString());
		book.MakePageObject(book.pages[pageNumber], 0);
//		book.UpdateBookMT();
//		book.UpdateAttachObject(book.pages[pageNumber], );

//		book.pages[pageNumber].UpdateAttached();

//		Debug.Log(book.pages.Count.ToString());
//		Debug.Log(book.pageparams.Count.ToString());

//		book.rebuildmeshes = true;
//		book.rebuild = true;
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
			if (GUILayout.Button("72"))
			{
				ReplacePage(GetPageNumber(72), 72);
			}
			if (GUILayout.Button("28"))
			{
				ReplacePage(GetPageNumber(28), 28);
			}

		} GUILayout.EndHorizontal();
	}

}
