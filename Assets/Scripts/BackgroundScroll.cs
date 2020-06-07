using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float scrollSpeed;
    private Renderer renderer_Bkg;

    void Start()
    {
        renderer_Bkg = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float offset = Time.time * scrollSpeed;
        renderer_Bkg.material.mainTextureOffset = new Vector2(offset, 0);
	}
}
