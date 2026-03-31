using UnityEngine;

public class Hole : MonoBehaviour
{

    public bool is_hole_active;
    public bool is_hole_occupied;

    public Vector3 HoleSize;

    [SerializeField] SpriteRenderer holeSpriteRenderer;

    void Start()
    {
        is_hole_active = true;
        is_hole_occupied = false;
        HoleSize = holeSpriteRenderer.bounds.size;
    }

    private void ChangeColor()
    {
        if (!is_hole_active)
        {
            holeSpriteRenderer.color = Color.black;
        }

        else
        {
            holeSpriteRenderer.color = Color.white;
        }
    }

}
