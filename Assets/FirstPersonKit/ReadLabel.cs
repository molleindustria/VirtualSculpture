using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadLabel : MonoBehaviour
{
    Camera cam;
    public float rayDistance = 5f;

    [Tooltip("If not assigned it will use the default one in the player prefab")]
    public TMP_Text messageField;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag != null)
            {
                Debug.Log("hit");
            }

            Label lab = hit.collider.gameObject.GetComponent<Label>();

            if (lab != null)
            {
                Debug.Log("hit" + lab.label);
                messageField.text = lab.label;
            }
            else
            {
                messageField.text = "";
            }

        }
        else
        {
            messageField.text = "";
        }

    }
}
