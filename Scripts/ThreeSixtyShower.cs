using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ThreeSixtyShower : MonoBehaviour {


	public Camera cam;
	public GameObject video;
	public ViewTimer timer;


	void Awake () {

		cam.nearClipPlane = Data.maxClipPlane;
	}


	public void openVideo (bool isOpening) {
		
		video.SetActive (true);
		StartCoroutine (ClipPlane(isOpening));

	}

	private IEnumerator ClipPlane (bool isOpening) {

		float i = 0;
		while (isOpening) {
				
			yield return new WaitForSeconds(Data.clipSpeed);

				if (cam.nearClipPlane <= 0.2f) break;

				cam.nearClipPlane -= i;
				i+=0.01f;

			}
		cam.nearClipPlane = Data.minClipPlane;
	}

	public void closeVideo (bool isClosing) {
		
		StartCoroutine (UnClipPlane(isClosing));
	}

	private IEnumerator UnClipPlane (bool isClosing) {

	
		float i = 0;
		while (isClosing ) {

			yield return new WaitForSeconds(Data.clipSpeed);

			if (cam.nearClipPlane >= 10f) break;
	
			cam.nearClipPlane += i;
			i+=0.01f;

		}

		cam.nearClipPlane = Data.maxClipPlane;
		video.SetActive(false);
		timer.scrollBar.size = 0;
		timer.StartTimer (true);

	}

























}
