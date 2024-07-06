using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendNeck : MonoBehaviour
{
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
    [SerializeField] private LayerMask groundMask;
    float currentBottomNeckPos = 0;
    float currentTopNeckPos = 0;
    private float minNeckLength;
    public float extendSpeed;

    [Header("Status")]
    public bool isNeckGoingBack;
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
        isGrounded = Physics.CheckSphere(duckFoot.position, 0.01f, groundMask);
        

        if (Input.GetKey(keyToExtendNeck) && isGrounded) 
        {
            ExtendTheNeck();
        }
        if (Input.GetKey(keyToShortenNeck) && !neckHasBack)
        {
            isNeckGoingBack = true;
            currentBottomNeckPos = rootController.position.y;
            currentTopNeckPos = topNeckBone.position.y;
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
