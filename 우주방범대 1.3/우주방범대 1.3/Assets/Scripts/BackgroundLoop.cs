using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private float height;
    public ScrollingDir currentDir;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x * transform.localScale.x;
        height = backgroundCollider.size.y * transform.localScale.y;
    }

    private void Update()
    {
        if ((currentDir == ScrollingDir.LEFT && transform.position.x <= -width)
            || (currentDir == ScrollingDir.RIGHT && transform.position.x >= width)
            || (currentDir == ScrollingDir.UP && transform.position.y >= height)
            || (currentDir == ScrollingDir.DOWN && transform.position.y <= -height))
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset;
        switch (currentDir)
        {
            case ScrollingDir.LEFT:
                offset = new Vector2(width * 2f, 0);
                transform.position = (Vector2)transform.position + offset;
                break;

            case ScrollingDir.RIGHT:
                offset = new Vector2(width * -2f, 0);
                transform.position = (Vector2)transform.position + offset;
                break;
            case ScrollingDir.DOWN:
                offset = new Vector2(0, height * 2f);
                transform.position = (Vector2)transform.position + offset;
                break;

            case ScrollingDir.UP:
                offset = new Vector2(0, height * -2f);
                transform.position = (Vector2)transform.position + offset;
                break;
        }
    }
}
