using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoTarget : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_cursPosition");
    public static int SizeID = Shader.PropertyToID("");

    //Temp store time
    public TextMeshProUGUI myTimer;

    //Stores the static material
    public Material tvStatic;

    private float targetHitTimer;

    private bool onTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        onTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Player must keep their mouse on the target, or else timer resets;
        if (onTarget)
        {
            targetHitTimer += Time.deltaTime;
        }
        else
        {
            targetHitTimer = 0;
        }
        Debug.Log(onTarget);
        myTimer.text = "Time: " + targetHitTimer.ToString("F1");
    }

    private void OnMouseOver()
    {
        onTarget = true;
        Debug.Log("Over mouse");

    }

    private void OnMouseExit()
    {
        onTarget = false;
    }
}
