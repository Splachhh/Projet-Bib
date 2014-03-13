using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{

	private AudioSource audioSource;
	public AudioClip[] Tracks;
	private AudioClip lastPlayingTrack;
	private bool isPlay;
	private float delayTime;

	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();
		changeTrack();
		isPlay = true;
		audioSource.ignoreListenerPause = true;
		delayTime = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//N'incremente pas le compteur si la musique ne se joue pas
		if (!isPlay)
			return;

		if (delayTime >= audioSource.timeSamples)
			changeTrack();
		
		delayTime += Time.deltaTime;
	}

	public void changeTrack()
	{
		if (!isPlay)
			return;
		
		if(audioSource.isPlaying)
			audioSource.Stop();
		
		int randomTrack = Random.Range(0, Tracks.Length-1);
		lastPlayingTrack = Tracks[randomTrack];
		
		startTrack();
		delayTime = 0f;
	}

	public void stopTrack()
	{
		lastPlayingTrack = audioSource.clip;
		audioSource.Stop();
	}
	
	public void pauseTrack()
	{
		audioSource.Pause();
	}
	
	public void startTrack()
	{
		if (lastPlayingTrack != null)
			audioSource.clip = lastPlayingTrack;
		else
			changeTrack();
		audioSource.Play();
	}
	
	public void changePlayState()
	{
		isPlay = !isPlay;
	}
	
	public bool getPlayState()
	{
		return isPlay;
	}

	public void changeVolume (float vol)
	{
		audioSource.volume = vol;
	}

	public float getVolume ()
	{
		return audioSource.volume;
	}
}
