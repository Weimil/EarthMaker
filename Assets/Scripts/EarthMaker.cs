using Level.ChunkStuff;
using Level.RegionStuff;
using Level.WorldStuff;
using LoadManagement;
using UnityEngine;

public class EarthMaker : MonoBehaviour
{
    public Region Region;
    public Chunk Chunk;

    private void Start()
    {
        gameObject.AddComponent<World>().Init(Region, Chunk);
        gameObject.AddComponent<LoadServer>().Init();

        GameObject.FindWithTag("Player").AddComponent<LoadClient>().Init(GetComponent<LoadServer>());
    }
}