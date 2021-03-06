
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,5f)]
    public float scrollSpeed = 1.75f;
    private float offset;
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }
 
    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

}
