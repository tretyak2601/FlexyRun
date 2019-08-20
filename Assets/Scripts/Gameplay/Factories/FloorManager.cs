using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] Floor floorPrefab;
    [SerializeField] BarrierManager barriers;
    [SerializeField] FlexyPlayer flexy;
    [SerializeField] GameObject[] platforms;

    [SerializeField] float yPos = -7.5f;

    private LinkedList<Floor> floors = new LinkedList<Floor>();
    private List<GameObject> platformsList = new List<GameObject>();

    private void Awake()
    {
        AddFloor();
        AddFloor();
        AddFloor();
        flexy.OnCreateFloorTriggered += AddFloor;
    }

    public void AddFloor()
    {
        Vector3 floorScale = floorPrefab.transform.localScale;
        float platformLength = platforms[0].transform.localScale.z;

        Vector3 instPos = floors.Count == 0 ?
            Vector3.zero + Vector3.forward * floorScale.z * 0.45f :
            floors.Last.Value.transform.position + Vector3.forward * platformLength + Vector3.forward * floorScale.z;

        var temp = Instantiate(floorPrefab, instPos, Quaternion.identity, transform);
        temp.Init(barriers, 5, instPos);
        floors.AddLast(temp);

        var platTemp = Instantiate(platforms[Random.Range(0, platforms.Length)], temp.transform.position + Vector3.forward * (temp.transform.localScale.z / 2 + platformLength / 2), Quaternion.identity);
        platformsList.Add(platTemp);
        
        if (floors.Count == 5)
        {
            floors.First.Value.Destroy();
            floors.RemoveFirst();
        }
    }

    public void Restart()
    {
        foreach (var f in floors)
            f.Destroy();

        foreach (var p in platformsList)
            Destroy(p.gameObject);

        floors.Clear();
        platformsList.Clear();
        AddFloor();
        AddFloor();
        AddFloor();
    }
}
