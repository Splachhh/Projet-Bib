using UnityEngine;
using System.Collections;

public class EnnemyCreator : MonoBehaviour 
{
	public LevelDifficulty lvl;
	public int MyDiffuculty;
	private GameObject obj;

	// Use this for initialization
	void Start () 
	{
		obj = GameObject.Find("Level");
		lvl = obj.GetComponent<LevelDifficulty>();
		MyDiffuculty = lvl.difficult;
		DestroyImmediate(obj);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
