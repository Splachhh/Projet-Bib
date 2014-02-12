using UnityEngine;
using System.Collections;

public class LevelDifficulty : MonoBehaviour {

	public int difficult;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}


	public void SetLevel(int lvl)
	{
		difficult = lvl;
	}

	public int GetLevel()
	{
		return difficult;
	}
}
