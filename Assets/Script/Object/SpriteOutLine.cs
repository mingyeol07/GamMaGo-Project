using UnityEngine;


//[ExecuteInEditMode]
public class SpriteOutLine : MonoBehaviour
{
    

    private SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateOutline(true);
    }

    void OnDisable()
    {
        UpdateOutline(false);
    }

    void Update()
    {
        UpdateOutline(true);
    }

    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", GameManager.ins.color);
        mpb.SetFloat("_OutlineSize", GameManager.ins.outlineSize);
        spriteRenderer.SetPropertyBlock(mpb);
    }
}