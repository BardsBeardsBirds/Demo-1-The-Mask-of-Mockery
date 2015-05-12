
using UnityEngine;
using System.Collections;
using System.Linq;

public static class ArrangeParticleSystems
{
    public static void LoadParticleSystem()
    {
        GameObject instance;
        if (GameObject.Find("Waterfall Particles") == null)
        {
            instance = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/World/Waterfall Particles")) as GameObject;
            instance.gameObject.name = "Waterfall Particles";
            GameObject waterfall = GameObject.Find("Waterfall Particles Spawnpoint");
            instance.transform.parent = waterfall.transform;
            instance.transform.position = waterfall.transform.position;
        }
    }

    public static void DeleteParticleSystem()
    {
        GameManager.Destroy("Waterfall Particles");
    }
}
