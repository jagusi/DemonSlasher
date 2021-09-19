using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] List<AudioClip> bgmList; 
    [SerializeField] List<AudioClip> sfxList;
    AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmList[0];
        audioSource.Play();
        audioSource.loop = true;
    }
    public void PlaySFXHit(int index )
    {
        audioSource.PlayOneShot(sfxList[index]);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
