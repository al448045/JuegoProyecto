using UnityEngine;

public class Hole : MonoBehaviour
{

    public bool is_hole_active;
    public bool is_hole_occupied;

    public Vector3 HoleSize;

    [SerializeField] SpriteRenderer holeSpriteRenderer;

    private void Start()
    {
        is_hole_active = true;
        is_hole_occupied = false;
        HoleSize = holeSpriteRenderer.bounds.size;
    }

    private void Update()
    {
        if (!is_hole_active)
        {
            holeSpriteRenderer.color = Color.white;
        }

        if (is_hole_occupied)
        {
            holeSpriteRenderer.color = Color.red;
        }

        else
        {
            holeSpriteRenderer.color = Color.blue;
        }
    }
}
