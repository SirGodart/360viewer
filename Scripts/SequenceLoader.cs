using UnityEngine;
using System.Collections;

public class SequenceLoader : DotProduct {


	private Object[] textureArray;
	private Renderer r;

	public ThreeSixtyShower videoShower;






	void Awake () {

		gameObject.SetActive(false);
	
	}

	void Start () {

		r = GetComponent<Renderer>();

	}
		
	public void StartVideo (bool isPlaying) {

		gameObject.SetActive(true);
		textureArray = null;
		textureArray = Resources.LoadAll(currentName);
		videoShower.openVideo(true);
		StartCoroutine (PlayTexture(isPlaying));

	}

	public IEnumerator PlayTexture (bool isPlaying) {
			int i = 0;
		while (isPlaying) {


			yield return new WaitForSeconds(0.05f);
				if (i >= textureArray.Length) {
					i = 0;
				}

				r.material.mainTexture = textureArray[i] as Texture2D;
				i++;

		}
		StopAllCoroutines();
	}




	void Update () {

	
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			
				videoShower.closeVideo (true);
		}




		if (Input.GetKey(KeyCode.LeftArrow)) {


			transform.Rotate(Vector3.up * Time.deltaTime * 100f);



		} else if (Input.GetKey(KeyCode.RightArrow)) {

			transform.Rotate(Vector3.up * Time.deltaTime * -100f);

		}
			
	}
}
