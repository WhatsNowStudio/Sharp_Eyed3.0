using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAssetsFromAbs : MonoBehaviour {
	public AssetBundle Abs;
	public string Name;
	public GameObject Child;
	public bool IsLoaded = false;

	void Start () {

	}

	void Process()
	{

		Child = null;
		IsLoaded = false;
		Child = Instantiate(Abs.LoadAsset (Name)as GameObject);
		if (Child != null) {
			IsLoaded = true;
		}
		Debug.Log ("從ABs打撈Asset");
	}
}