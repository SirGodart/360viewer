using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DotProduct : MonoBehaviour {


	public Camera cam;
	public ViewTimer timer;
	public Canvas scrollbar;

	public static string currentName;

	private GameObject[] obj;



	void Awake () {
		scrollbar.enabled = false;
	}


	void Start () {
		obj = GameObject.FindGameObjectsWithTag("moviePlane");
		print (obj.Length);
	}


	public IEnumerator movePlane (Collider col, float delay, int decider) {

		float length = 0;
		while (length < Data.movePlaneDuration) {

			yield return new WaitForSeconds(delay);
			col.transform.Translate (Vector3.up * (length * decider));
			length += Data.movePlaneSpeed;
			}
			
		}




    public void resetTimer () {


		if (scrollbar.enabled) {
			timer.StartTimer(true);
		} else {
			timer.StopAllCoroutines();
		}

		timer.scrollBar.size = 0;
	

	}
		

	void OnTriggerEnter(Collider col) {


		for (int i= 0; i < Data.numberOfItems; i++) {
			if (col.gameObject.name == "plane"+i) {
				currentName = col.gameObject.name; 
			
				timer.scrollBar.size = 0;
				StartCoroutine(movePlane(col, 0.01f, -1));
			}

		}

	}

	void OnTriggerExit (Collider col) {

		for (int i= 0; i < Data.numberOfItems; i++) {
			
			if (col.gameObject.name == "plane"+i) {
				
				timer.scrollBar.size = 0;
				StartCoroutine(movePlane(col, 0.01f, 1));
			}
		}

	}

	void Update () {



		
			


		if (Input.GetKeyDown(KeyCode.UpArrow)) {

			scrollbar.enabled = !scrollbar.enabled;
			resetTimer ();

		}
	}
}
