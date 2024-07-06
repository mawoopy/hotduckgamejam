using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackControl : MonoBehaviour
{
    [SerializeField]private AudioSource quackAudioSource;
    [SerializeField]private AudioClip quackSound;
    [SerializeField]private KeyCode quackKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(quackKey))
        {
            quackAudioSource.Play();
        }
    }
}
