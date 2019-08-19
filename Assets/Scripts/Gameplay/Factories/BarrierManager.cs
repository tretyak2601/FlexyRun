using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Barriers Data")]
public class BarrierManager : ScriptableObject
{
    [SerializeField] List<Barrier> barriersList;
    public List<Barrier> BarriersList { get { return barriersList; } }
}
