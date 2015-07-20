using System.Collections;
using UnityEngine;

public class PickUpItemListener : MonoBehaviour
{
    public enum ItemType { Coin, TenCoins, HundredCoins, Other };

    public ItemType thisItemType;
    public PickUpItemListener Instance;
    public GameObject PickUpSoundGo;

    public void Awake()
    {
        Instance = this;

        PickUpSoundGo = GameObject.Find("PickupCoinsAudio");
        PickUpSoundGo.GetComponent<AudioSource>().clip = Resources.Load("Audio/Effects/PickingUp/Coins") as AudioClip ;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        GameObject particleEffect;

        if (Instance.thisItemType == ItemType.Coin)
        {
            GameManager.Instance.ChangeMoney(1);
            particleEffect = GameObject.Instantiate(Resources.Load("Prefabs/Particles/PickupYellow")) as GameObject;
            particleEffect.transform.position = Instance.transform.position;
            PickUpSoundGo.GetComponent<AudioSource>().Play();
        }
        else if (Instance.thisItemType == ItemType.TenCoins)
        {
            GameManager.Instance.ChangeMoney(10);
            GameManager.Instance.ChangeMoney(1);
            particleEffect = GameObject.Instantiate(Resources.Load("Prefabs/Particles/PickupRed")) as GameObject;
            particleEffect.transform.position = Instance.transform.position;
            PickUpSoundGo.GetComponent<AudioSource>().Play();
        }
        else if (Instance.thisItemType == ItemType.HundredCoins)
        {
            GameManager.Instance.ChangeMoney(100);
            PickUpSoundGo.GetComponent<AudioSource>().Play();
        }
        Destroy();
    }

    private void Destroy()
    {
        Destroy(this.transform.gameObject);
    }
}

