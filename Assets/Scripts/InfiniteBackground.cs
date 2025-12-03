using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, 0.4f) * Time.deltaTime;
    }
}
