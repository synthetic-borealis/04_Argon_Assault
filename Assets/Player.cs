using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float speed = 20f;
    [Tooltip("In m")][SerializeField] float xRange = 5f;
    [Tooltip("In m")][SerializeField] float yRange = 3f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffsetThisFrame;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
