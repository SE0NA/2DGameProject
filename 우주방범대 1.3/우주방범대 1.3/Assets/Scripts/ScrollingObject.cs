using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollingDir
{
    LEFT, RIGHT, UP, DOWN
}

public class ScrollingObject : MonoBehaviour
{
    public float speed = 5f;

    public ScrollingDir currentDir;

    private void Update()
    {
        switch (currentDir)
        {
            case ScrollingDir.DOWN:
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                break;

            case ScrollingDir.UP:
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                break;

            case ScrollingDir.LEFT:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;

            case ScrollingDir.RIGHT:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
        }
    }
}
