using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject blockPrefab;
    
    
    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(i, j, 0), Quaternion.identity);
                block.transform.SetParent(transform);
            }
        }
    }
}