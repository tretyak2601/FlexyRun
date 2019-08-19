using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private BarrierManager barriers;
    private List<Barrier> instBarriers = new List<Barrier>();

    public void Init(BarrierManager barriers, int barriersCount, Vector3 position)
    {
        this.barriers = barriers;

        int distance = Mathf.RoundToInt(transform.localScale.z / barriersCount);

        for (int i = 1; i <= barriersCount; i++)
        {
            int rand = Random.Range(0, barriers.BarriersList.Count);
            var temp = Instantiate(barriers.BarriersList[rand],
                new Vector3(-barriers.BarriersList[rand].Width, 5, position.z + distance * i),
                Quaternion.identity);

            instBarriers.Add(temp);
        }
    }

    public void Destroy()
    {
        foreach (var bar in instBarriers)
            GameObject.Destroy(bar.gameObject);

        instBarriers.Clear();
        Destroy(gameObject);
    }
}
