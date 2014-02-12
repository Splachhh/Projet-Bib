using UnityEngine;
using System.Collections;

public class EnnemyCreator : MonoBehaviour 
{
	private LevelDifficulty lvl;
	private int MyDiffuculty;
	private GameObject obj;

	public int getDificulty() {return MyDiffuculty;}
	void Awake()
	{
		obj = GameObject.Find("Level");
		lvl = obj.GetComponent<LevelDifficulty>();
		MyDiffuculty = lvl.GetLevel();
		DestroyImmediate(obj);
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
