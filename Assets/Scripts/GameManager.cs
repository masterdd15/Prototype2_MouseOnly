using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreHolder;
    private int score;
    public GameObject videoTarget;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreHolder.text = "Score: " + score;
        videoTarget.transform.position = NewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator NewTarget()
    {
        //We scored a point
        score += 1;
        scoreHolder.text = "Score: " + score;
        //Now we have to move our gameobject
        yield return new WaitForSeconds(2f);
        videoTarget.GetComponent<VideoTarget>().ResetStatic();
        yield return new WaitForSeconds(.1f);
        videoTarget.transform.position = NewPosition();
    }

    public Vector2 NewPosition()
    {
        //We generate a new position for our target
        float x;
        float y;
        x = Random.Range(-6.5f, 4);
        y = Random.Range(-2.5f, 2.9f);
        return new Vector2(x, y);
    }
}
