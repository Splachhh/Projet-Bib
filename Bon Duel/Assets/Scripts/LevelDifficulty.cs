using UnityEngine;
using System.Collections;

public class LevelDifficulty : MonoBehaviour {

	public int difficult = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void setEasy()
	{
		difficult = 0;
	}

	void setMedium()
	{
		difficult = 1;
	}

	void setHard()
	{
		difficult = 2;
	}
}
