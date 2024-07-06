using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendNeck : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform topNeckBone;
    private Transform rootController;
    private float topNeckPos;
    private float startTopNeckPos;
    [Header("Controls")]
    [SerializeField] private KeyCode keyToExtendNeck;
    [SerializeField] private KeyCode keyToShortenNeck;

    [Header("Variables")]
    [SerializeField] private float maxNeckLength;
    private float minNeckLength;
    public float extendSpeed;

    [Header("Status")]
    public bool isNeckExtending;
    // Start is called before the first frame update
    void Start()
    {
        rootController = GetComponent<Transform>();
        startTopNeckPos = topNeckBone.position.y;
        minNeckLength = startTopNeckPos - rootController.position.y;
        topNeckPos = Mathf.Clamp(topNeckBone.position.y, startTopNeckPos, startTopNeckPos + maxNeckLength);
    }

    // Update is called once per frame
    void Update()
    {
        topNeckPos = Mathf.Clamp(topNeckBone.position.y, startTopNeckPos, startTopNeckPos + maxNeckLength);

        if (Input.GetKey(keyToExtendNeck)) 
        {
            ExtendTheNeck();
        }
        if (Input.GetKey(keyToShortenNeck))
        {
            ShortenNeck();
        }
    }

    public void ExtendTheNeck()
    {
        topNeckPos += extendSpeed * Time.deltaTime;
        topNeckBone.position = new Vector3(topNeckBone.position.x, topNeckPos, topNeckBone.position.z);
    }

    public void ShortenNeck()
    {
        float bottomNeckPos = topNeckPos - minNeckLength;
        rootController.position = new Vector3(rootController.position.x, bottomNeckPos, rootController.position.z);

        topNeckPos = bottomNeckPos + minNeckLength;
        topNeckBone.position = new Vector3(topNeckBone.position.x, topNeckPos, topNeckBone.position.z);
    }
}
