using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager mInstance;

	public string androidLog = "JYP";
	// Use this for initialization

	public AndroidJavaObject activity;

	void Awake()
	{
		AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		activity = jc.GetStatic<AndroidJavaObject> ("currentActivity");
	}

	void AndroidLog(string newAndroidLog)
	{
		androidLog = newAndroidLog;
		PutStone ("a");
	}

	void PutStone(string context) {
//		OnReceive(new Vector2(19f,19f), true);
//		char[] delimiterChars = {' ',};
//		string[] words = context.Split(delimiterChars);
		string axisX_str = "5";
		string axisY_str = "5";
		string isBlack_str = "true";

		float axisX	= System.Convert.ToSingle(axisY_str);
		float axisY = System.Convert.ToSingle(axisX_str);
		bool isBlack = System.Convert.ToBoolean (isBlack_str);

		OnReceive(new Vector2(axisX,axisY), isBlack);
	}

	public static GameManager Instance {
		get {
			if (mInstance == null) {
				mInstance = FindObjectOfType (typeof(GameManager)) as GameManager;
				if (mInstance == null) {
					mInstance = new GameObject ("GameManager").AddComponent<GameManager> ();
				}
			}
			return mInstance;
		}
	}

	public GameObject black;
	public GameObject white;
	public GameObject grid;

	Vector2 input;

	void Start() {
		for (float i = 1; i <= 19; i++) {
			for (float j = 1; j <= 19; j++) {
				Instantiate (grid, new Vector2(i,j), Quaternion.identity);
			}
		}
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.A)) {
			OnReceive(new Vector2(1f,1f), true);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			OnReceive(new Vector2(19f,19f), false);
		}	
	}

	void OnReceive(Vector2 input, bool isBlack) {
		if (isBlack) {
			Instantiate (black, input, Quaternion.identity);
		} else {
			Instantiate (white, input, Quaternion.identity);
		}
	}

}
