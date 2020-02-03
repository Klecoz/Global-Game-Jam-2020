using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip clickNoise;
    AudioSource audio;
    public GameObject leftHand;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetGame();
    }

    public void PlayClickNoise()
    {
        audio.PlayOneShot(clickNoise);
    }

    // TODO: Reset Position on Pinch
    public void ResetGame()
    {
        var rightHandThings = rightHand.GetComponent<OVRHand>();
        var isRightHandPinching = rightHandThings.GetFingerIsPinching(OVRHand.HandFinger.Ring);
        var rightHandFingerStrength = rightHandThings.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        if (isRightHandPinching && rightHandFingerStrength == 1)
            SceneManager.LoadScene(0);
    }
    //TODO: Find positions of pieces


}
