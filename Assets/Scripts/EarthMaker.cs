using Level.ChunkStuff;
using Level.RegionStuff;
using Level.WorldStuff;
using LoadManagement;
using Miscellaneous;
using UnityEngine;

public class EarthMaker : MonoBehaviour
{
    public Region Region;
    public Chunk Chunk;

    private void Start()
    {
        Constants.Chunk = Chunk;
        Constants.Region = Region;

        gameObject.AddComponent<World>().Init();
        gameObject.AddComponent<LoadServer>().Init();

        GameObject.FindWithTag("Player").AddComponent<LoadClient>().Init(GetComponent<LoadServer>());
    }
}