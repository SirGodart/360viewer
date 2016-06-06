using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class MovieRing : MonoBehaviour {



	private MoviePlane spawn;
	private Renderer planeRenderer;
	private MoviePlane[] planeArray;
	private float headRotation;
	private Object[] textureArray;

	public MoviePlane plane;
	public Shader maskShader;


	void Awake () {


		textureArray = Resources.LoadAll("planeTextures");

		for (int i = 0; i < Data.numberOfItems; i++) {

			//rect is 10 squares in width
			float rad = 10f / Mathf.Tan (Mathf.PI / Data.numberOfItems);
			float angle = (i / Data.numberOfItems) * Mathf.PI * 2.0f ;
			float x = Mathf.Sin(angle) * rad ;
			float z = Mathf.Cos(angle) * rad ;

			spawn = Instantiate<MoviePlane>(plane);
			spawn.transform.parent = transform;
			spawn.tag = "moviePlane";
			spawn.name = "plane"+i;

			spawn.transform.localPosition = new Vector3 ( x, 0, z);
			spawn.transform.localRotation = Quaternion.Euler (90, 360 / Data.numberOfItems * i, 0);

			setupTexture (i);

		}

	}
		

	private void setupTexture (int i) {

		planeRenderer = spawn.GetComponent<Renderer>();
		planeRenderer.material.mainTexture = textureArray[i] as Texture2D;
		//planeRenderer.material.shader = maskShader;
	
	}


	void Start () {

		//InvokeRepeating("CheckForOculus", 0, 0.01f);
	}


	void CheckForOculus () {

		if (VRDevice.isPresent) {
			
			print("present");
			InputTracking.Recenter();
			CancelInvoke();
		}

	}


	private void controlRotation () {

		float euler = InputTracking.GetLocalRotation(VRNode.Head).eulerAngles.y;





		if (euler > 20 && euler < 45) {
			transform.Rotate(0,  -Data.headRotationSpeed/2 * Time.deltaTime , 0);

		} else if ( euler > 45 && euler < 90) {
			transform.Rotate(0,  -Data.headRotationSpeed*3 * Time.deltaTime , 0);

		} else if ( euler < 340 && euler > 315) {
			transform.Rotate(0,  Data.headRotationSpeed/2 * Time.deltaTime , 0);

		} else if ( euler <  315 && euler > 270) {
			transform.Rotate(0,  Data.headRotationSpeed*3 * Time.deltaTime , 0);

		}



	}
		
	void Update () {

		//VR HEAD
		//controlRotation ();

		//float offset = Time.time * 2f;
		//planeRenderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));


		if (Input.GetKey(KeyCode.LeftArrow)) {


			transform.Rotate(Vector3.up * Time.deltaTime * 100f);
	
		

		} else if (Input.GetKey(KeyCode.RightArrow)) {

			transform.Rotate(Vector3.up * Time.deltaTime * -100f);

		}


	}



}
