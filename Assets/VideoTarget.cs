using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoTarget : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_cursPosition");
    public static int SizeID = Shader.PropertyToID("_circleSize");

    //GameManager
    private GameManager gm;

    private bool hasGotten;

    //Temp store time
    public TextMeshProUGUI myTimer;

    //Stores the static material
    public Material tvStatic;

    //The size of our circle
    [SerializeField]
    private float revealSize;

    private float targetHitTimer;

    private bool onTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        onTarget = false;
        hasGotten = false;
        revealSize = .5f;
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
        myTimer.text = "Time: " + targetHitTimer.ToString("F1");

        //Set the circle size on the material
        if (targetHitTimer <= 2f) { 
            tvStatic.SetFloat(SizeID, revealSize + targetHitTimer);
        }
        else
        {
            if (!hasGotten)
            {
                revealSize = Mathf.Lerp(3f, 100f, 3f);
                tvStatic.SetFloat(SizeID, revealSize);
                hasGotten = true;
                StartCoroutine(gm.NewTarget()); //Adds a point and moves target
            }
        }
    }

    private void OnMouseOver()
    {
        onTarget = true;

    }

    private void OnMouseExit()
    {
        onTarget = false;
    }

    public void ResetStatic()
    {
        onTarget = false;
        revealSize = .5f;
        targetHitTimer = 0;
        hasGotten = false;
    }
}
