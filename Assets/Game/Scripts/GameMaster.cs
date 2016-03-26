using UnityEngine;
using System.Collections;

public static class GameMaster
{
	public static int currentPageNumber { get; private set; }

	public static System.Action<int> onGoToPage;

	public static void GoToPage(int pageNumber)
	{
		currentPageNumber = pageNumber;

		if (onGoToPage != null)
		{
			onGoToPage(pageNumber);
		}
	}

}
