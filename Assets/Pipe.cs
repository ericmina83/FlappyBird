using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Hole
{
    public float center;//in ratio
    public float height; // in ratio

    public Hole(float center, float holeWidth)
    {
        this.center = center;
        this.height = holeWidth;
    }

    public float GetTopBound()
    {
        return center + height / 2;
    }

    public float GetBottomBound()
    {
        return center - height / 2;
    }
}

public class Pipe : MonoBehaviour
{
    public PipeHead topPipe;
    public PipeHead bottomPipe;

    // Start is called before the first frame update
    void Start()
    {
        SetGap();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void InitPipe(Hole gap)
    {
        topPipe.SetAsTopPipe(gap.GetTopBound());
        bottomPipe.SetAsBottomPipe(gap.GetBottomBound());
    }

    public void SetGap()
    {
        var mapHigh = GameSystem.instance.mapHeight;
        float holeWidthHalf = Random.Range(
            mapHigh * GameSystem.instance.holeMinRatio,
            mapHigh * GameSystem.instance.holeMaxRatio);
        float center = Random.Range(-mapHigh + holeWidthHalf, mapHigh - holeWidthHalf);
        InitPipe(new Hole(center, holeWidthHalf * 2));
    }

    public void Move()
    {
        var position = transform.position;
        position.x -= GameSystem.instance.mapSpeed * Time.deltaTime;

        if (position.x < -GameSystem.instance.mapRange)
        {
            SetGap();
            position.x = GameSystem.instance.mapRange;
        }
        transform.position = position;
    }
}
