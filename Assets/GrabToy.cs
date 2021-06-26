using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GrabToy : MonoBehaviour
{
    private ManoGestureContinuous grab;
    private string handTag = "Player";
//    public ARPlaneManager planes;
    FindFloor floor;
//    Rigidbody rb;
    GameObject hand;
    bool handattoy;
    // Start is called before the first frame update
    void Start()
    {
  //      floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<FindFloor>();
  //      rb = GetComponent<Rigidbody>();
        hand = GameObject.FindGameObjectWithTag(handTag);
        Initialize();
    }

 
    private void Update()
    {
 //       if (floor.floormade)
        {
 //           rb.useGravity = true;
  //          rb.isKinematic = false;
        }
    }
    private void Initialize()
    {
        grab = ManoGestureContinuous.CLOSED_HAND_GESTURE;
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">The collider that stays</param>
    private void OnTriggerStay(Collider other)
    {
        MoveWhenGrab(other);
    }

    /// <summary>
    /// If grab is performed while hand collider is in the cube.
    /// The cube will follow the hand.
    /// </summary>
    private void MoveWhenGrab(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == grab)
        {
   //         rb.useGravity = false;
     //       rb.isKinematic = true;
            transform.parent = other.gameObject.transform;
            Debug.Log("follow me");
        }

        else
        {
            transform.parent = null;
            Debug.Log("unfollow");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == handTag)
        {
            Handheld.Vibrate();
        }
    }
}
