using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    [SerializeField] public BruteEnemy testEnemy;
    [SerializeField] public MonoBehaviour player;

    [SerializeField] private Hole[] Holes;


    public List<Hole> SearchAvaliableHoles()
    {

        Hole[] CurrentHoles = Holes;
        List<Hole> AvaliableHoles = new List<Hole>();

        foreach (Hole hole in CurrentHoles)
        {
            if ((!hole.is_hole_occupied) && (hole.is_hole_active))
            {
                AvaliableHoles.Add(hole);
            }
        }
        return AvaliableHoles;
    }

}
