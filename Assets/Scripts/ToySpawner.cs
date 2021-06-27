using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ToySpawner : MonoBehaviour
{

    private GameObject spawnNew;

    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
    [SerializeField]
    public GameObject[] objectArray;

    int i = 0;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Awake() {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arPlaneManager = GetComponent<ARPlaneManager>();

    }


    private bool TryToGetTouchPosition(out Vector2 touchPosition) {
        if (Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;

        return false;
    }


    private void Update() {
        if (!TryToGetTouchPosition(out Vector2 touchPosition))
            return;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            if (_arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes)) {
                var hitPose = hits[0].pose;
                foreach (var plane in _arPlaneManager.trackables) {
                    plane.gameObject.SetActive(false);
                }
                _arPlaneManager.enabled = false;

                spawnNew = Instantiate(objectArray[i], hitPose.position, hitPose.rotation);
                i++;
            }

        }
    }


}
