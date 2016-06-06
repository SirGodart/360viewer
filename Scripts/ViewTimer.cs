using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ViewTimer: MonoBehaviour {

	public  Scrollbar scrollBar;
	public SequenceLoader sequenceLoader;




	public void StartTimer (bool isIncreasing) {

		StartCoroutine (IncreaseTimer(isIncreasing));
	
	}
		
		
	public  IEnumerator IncreaseTimer (bool isIncreasing) {

		WaitForSeconds sec = new WaitForSeconds(0.02f);

		while (isIncreasing) {
				
			yield return sec;

			if (scrollBar.size >= 1) {
				sequenceLoader.StartVideo(true);
				break;
			}
				
	
			scrollBar.size += 0.01f;
		}
		StopAllCoroutines();

	}

}
