using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FindFloor : MonoBehaviour
{
 //   ARRaycastManager raymangaer;
    // Start is called before the first frame update
    public bool floormade = false;
    [SerializeField] 
    GameObject floor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raymangaer.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count > 0 && !floormade)
        {
            Instantiate(floor, hits[0].pose.position, Quaternion.identity);
            floormade = true;
        }*/
    }
}
