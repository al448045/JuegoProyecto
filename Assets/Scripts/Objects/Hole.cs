using System.Reflection.Emit;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public bool is_hole_active;
    public bool is_hole_occupied;

    public Vector3 HoleSize;

    public SpriteRenderer holeSpriteRenderer;

    private void Start()
    {
        holeSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        is_hole_active = true;
        is_hole_occupied = false;
        HoleSize = holeSpriteRenderer.bounds.size * 2;
    }
}
