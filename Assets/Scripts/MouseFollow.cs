using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    public static int PosID = Shader.PropertyToID("_cursPosition");

    public Material tvMaterial;
    public Camera currentCamera;
    public LayerMask Mask;
    public Vector2 cursorPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        var view = currentCamera.WorldToViewportPoint(transform.position);
        //var view = currentCamera.WorldToScreenPoint(transform.position);
        tvMaterial.SetVector(PosID, view);
    }
}
