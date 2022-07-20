using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAsTopPipe(float topBound)
    {
        float center = (GameSystem.instance.mapHeight + topBound) / 2;
        float pipeHeight = GameSystem.instance.mapHeight - topBound;
        ResizePipe(center, pipeHeight);
    }

    public void SetAsBottomPipe(float bottomBound)
    {
        float center = (bottomBound - GameSystem.instance.mapHeight) / 2;
        float pipeHeight = bottomBound + GameSystem.instance.mapHeight;
        ResizePipe(center, pipeHeight);
    }

    void ResizePipe(float centerY, float scaleY)
    {

        transform.localPosition = new Vector3(0, centerY, 0);
        transform.localScale = new Vector3(1, scaleY, 1);
    }

}
