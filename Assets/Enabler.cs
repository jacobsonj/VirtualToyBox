using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enabler : MonoBehaviour
{
    public Button btn;
    public GameObject enabledObject;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(MakeActive);
    }

    void MakeActive()
    {
        enabledObject.SetActive(!enabledObject.activeSelf);

    }
}
