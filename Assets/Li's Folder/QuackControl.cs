using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuackControl : MonoBehaviour
{
    [SerializeField] private UnityEvent onQuack;

    [SerializeField]private KeyCode quackKey;
    [Header("Eat Flies")]
    [SerializeField] private LayerMask fliesLayer;
    [SerializeField] private Transform mouthTransform;
    [SerializeField] private float eatRadius;
    [Header("Eating Statud")]
    public bool mouseIsOpen;
    public int fliesEatNum;
    bool hasPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(quackKey))
        {
            if (!hasPlayed)
            {
                onQuack.Invoke();
                hasPlayed = true;
            }
            
            mouseIsOpen = true;
            Debug.Log("quacking");
        }

        if (Input.GetKeyUp(quackKey))
        {
            hasPlayed = false;
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
