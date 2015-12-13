
using UnityEngine;
using System.Collections;
using System.Linq;

public static class ArrangeParticleSystems
{
    public static GameObject WaterfallParticles = null;
    public static GameObject RoughneckShotEffect = null;

    public static void LoadWaterfallParticlesAndSound()
    {
        if (WaterfallParticles == null)
        {
            WaterfallParticles = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/World/Waterfall Particles")) as GameObject;
            WaterfallParticles.gameObject.name = "Waterfall Particles";
            GameObject spawn = GameObject.Find("Waterfall Particles Spawnpoint");
            WaterfallParticles.transform.parent = spawn.transform;
            WaterfallParticles.transform.position = spawn.transform.position;
        }
    }

    public static void DeleteWaterfallParticlesAndSound()
    {
        if (WaterfallParticles != null)
            GameManager.Destroy(WaterfallParticles);
    }

    public static void LoadRoughneckShotEffect()
    {
        if (RoughneckShotEffect == null)
        {
            RoughneckShotEffect = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/RoughneckShotEffect")) as GameObject;
            RoughneckShotEffect.gameObject.name = "Roughneck Shot Effect";
            Transform spawn = GameManager.Player.transform.Find("Particle Effects");
            RoughneckShotEffect.transform.parent = spawn;
            RoughneckShotEffect.transform.position = spawn.position;
            RoughneckShotEffect.transform.position = new Vector3(RoughneckShotEffect.transform.position.x, RoughneckShotEffect.transform.position.y + 1.6f, RoughneckShotEffect.transform.position.z);
        }
    }

    public static void DeleteRoughneckShotEffect()
    {
        if (RoughneckShotEffect != null)
        {
            RoughneckShotEffect.GetComponent<ParticleSystem>().enableEmission = false;
            RoughneckShotEffect.GetComponent<DestroyAfterPlayback>().StartDestroying = true;
        }
    }
}