using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtendNeck : MonoBehaviour
{
    [SerializeField] private UnityEvent onShrinkNeck;
    [SerializeField] private UnityEvent onStretchNeckStop;
    [SerializeField] private UnityEvent onStretchNeckStart;

    [Header("Components")]
    [SerializeField] private Transform topNeckBone;
    [SerializeField] private Transform duckFoot;
    private Transform rootController;
    private Rigidbody rigidbody;
    private float topNeckPos;
    private float startTopNeckPos;
    [Header("Controls")]
    [SerializeField] private KeyCode keyToExtendNeck;
    [SerializeField] private KeyCode keyToShortenNeck;

    [Header("Variables")]
    [SerializeField] private float maxNeckLength;
    [SerializeField] private float timeToShortenNeck;
    [SerializeField] private float groundDistanceCheck = 0.05f;
    [SerializeField] private LayerMask groundMask;
    float currentBottomNeckPos = 0;
    float currentTopNeckPos = 0;
    private float minNeckLength;
    public float extendSpeed;
    private bool isExtending = false;

    [Header("Status")]
    public bool isNeckGoingBack = false;
    public bool isGrounded;
    public bool neckHasBack;
    // Start is called before the first frame update
    void Start()
    {
        rootController = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        startTopNeckPos = topNeckBone.position.y;
        minNeckLength = startTopNeckPos - rootController.position.y;
        topNeckPos = Mathf.Clamp(topNeckBone.position.y, startTopNeckPos, startTopNeckPos + maxNeckLength);
    }

    // Update is called once per frame
    void Update()
    {
        topNeckPos = Mathf.Clamp(topNeckBone.position.y, startTopNeckPos, startTopNeckPos + maxNeckLength);
        if (!isGrounded) isGrounded = Physics.CheckSphere(duckFoot.position, groundDistanceCheck, groundMask);
        

        if (Input.GetKey(keyToExtendNeck) && isGrounded) 
        {
            if (!isExtending) {
                isExtending = true;
                onStretchNeckStart.Invoke();
            }
            ExtendTheNeck();
            Debug.Log("extending neck");
        }
        if (!Input.GetKey(keyToExtendNeck)) {
            isExtending = false;
            onStretchNeckStop.Invoke();
        }
        if (Input.GetKey(keyToShortenNeck) && !neckHasBack)
        {
            if (!isNeckGoingBack) {
                isNeckGoingBack = true;
                onShrinkNeck.Invoke();
            }
            currentBottomNeckPos = rootController.position.y;
            currentTopNeckPos = topNeckBone.position.y;

            onShrinkNeck.Invoke();
            Debug.Log("going back");
        }

        if (isNeckGoingBack)
        {
            rigidbody.Sleep();
            ShortenNeck();
        }
        else
        {
            rigidbody.WakeUp();
        }

        if (topNeckBone.position.y - rootController.position.y <= minNeckLength)
        {
            neckHasBack = true;
        }
        else
        {
            neckHasBack = false;
        }
    }

    public void ExtendTheNeck()
    {
        topNeckPos += extendSpeed * Time.deltaTime;
        topNeckBone.position = new Vector3(topNeckBone.position.x, topNeckPos, topNeckBone.position.z);
    }

    public void ShortenNeck()
    {
        float speedForShortening = (currentTopNeckPos - currentBottomNeckPos) / timeToShortenNeck;
        float cBottomNeckPos = rootController.position.y;
        float bottomNeckPos = cBottomNeckPos +  speedForShortening * Time.deltaTime;
        
        rootController.position = new Vector3(rootController.position.x, bottomNeckPos, rootController.position.z);
        topNeckBone.position = new Vector3(topNeckBone.position.x, currentTopNeckPos, topNeckBone.position.z);

        if (topNeckPos - bottomNeckPos <= minNeckLength)
        {
            isNeckGoingBack = false;
        }
    }
}
