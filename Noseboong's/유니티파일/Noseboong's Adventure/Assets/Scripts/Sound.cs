using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SoundOFF()
    {
        audioSource.Stop();
        Debug.Log("Tlqkfdddddddddddd");
    }
    private void SoundON()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundON();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SoundOFF();
    }

}
