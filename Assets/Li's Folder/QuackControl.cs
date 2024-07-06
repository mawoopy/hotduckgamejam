using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackControl : MonoBehaviour
{
    [Header("Audio Component")]
    private AudioSource quackAudioSource;
    [SerializeField]private AudioClip quackSound;
    [SerializeField]private KeyCode quackKey;
    [Header("Eat Flies")]
    [SerializeField] private LayerMask fliesLayer;
    [SerializeField] private Transform mouthTransform;
    [SerializeField] private float eatRadius;
    [Header("Eating Statud")]
    public bool mouseIsOpen;
    public int fliesEatNum;
    bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        quackAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(quackKey))
        {
            if (!hasPlayed)
            {
                quackAudioSource.Play();
                hasPlayed = true;
            }
            
            mouseIsOpen = true;
            Debug.Log("quacking");
        }

        if (Input.GetKeyUp(quackKey))
        {
            hasPlayed = false;
            quackAudioSource.Stop();
            Collider[] flyCollider = Physics.OverlapSphere (mouthTransform.position, eatRadius, fliesLayer);
            if (flyCollider.Length > 0)
            {
                fliesEatNum++;
                foreach (Collider col in flyCollider)
                {
                    Destroy (col.gameObject);
                    Debug.Log("Fly eaten");
                }
            }
            mouseIsOpen = false;
        }
    }
}
