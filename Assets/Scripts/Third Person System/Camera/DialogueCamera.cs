using UnityEngine;

public class DialogueCamera : MonoBehaviour
{
    public Transform Overview;
    public Transform Emmon;
    public Transform EmmonClose;
    public Transform NPC;
    public Transform NPCClose;
    public Transform OverShoulder;
    public Transform TopDown;
    public Transform EstablishmentShot;
    public Transform Custom1;
    public Transform Custom2;
    public Transform Custom3;
    public Transform Custom4;
    public Transform Custom5;

    public void Awake()
    {
        Overview = transform.Find("Overview");
        Emmon = transform.Find("Emmon");
        EmmonClose = transform.Find("EmmonClose");
        NPC = transform.Find("NPC");
        NPCClose = transform.Find("NPCClose");
        OverShoulder = transform.Find("OverShoulder");
        TopDown = transform.Find("TopDown");
        EstablishmentShot = transform.Find("EstablishmentShot");
        Custom1 = transform.Find("Custom1");
        Custom2 = transform.Find("Custom2");
        Custom3 = transform.Find("Custom3");
        Custom4 = transform.Find("Custom4");
        Custom5 = transform.Find("Custom5");

    }

    public void FindAngle(Camera camera, SpokenLine spokenLine)
    {
        CameraAngle angle = CameraAngle.Overview;
        CameraMoves camMove = CameraMoves.None;

        if (spokenLine.CamAngle != CameraAngle.Overview)
            angle = spokenLine.CamAngle;

        if (spokenLine.CamMovement != CameraMoves.None)
            camMove = spokenLine.CamMovement;

        Debug.LogWarning("find new angle for " + spokenLine.ID + ". angle: " + angle);

        if (angle == CameraAngle.Overview)
        {
            camera.transform.position = Overview.position;
            camera.transform.rotation = Overview.rotation;
            Overview.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.Emmon)
        {
            camera.transform.position = Emmon.position;
            camera.transform.rotation = Emmon.rotation;
            Emmon.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.EmmonClose)
        {
            camera.transform.position = EmmonClose.position;
            camera.transform.rotation = EmmonClose.rotation;
            EmmonClose.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.NPC)
        {
            camera.transform.position = NPC.position;
            camera.transform.rotation = NPC.rotation;
            NPC.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.NPCClose)
        {
            camera.transform.position = NPCClose.position;
            camera.transform.rotation = NPCClose.rotation;
            NPCClose.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }

        else if (angle == CameraAngle.OverShoulder)
        {
            camera.transform.position = OverShoulder.position;
            camera.transform.rotation = OverShoulder.rotation;
            OverShoulder.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.TopDown)
        {
            camera.transform.position = TopDown.position;
            camera.transform.rotation = TopDown.rotation;
            TopDown.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.EstablishmentShot)
        {
            camera.transform.position = EstablishmentShot.position;
            camera.transform.rotation = EstablishmentShot.rotation;
            EstablishmentShot.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.Custom1)
        {
            camera.transform.position = Custom1.position;
            camera.transform.rotation = Custom1.rotation;
            Custom1.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.Custom2)
        {
            camera.transform.position = Custom2.position;
            camera.transform.rotation = Custom2.rotation;
            Custom2.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.Custom3)
        {
            camera.transform.position = Custom3.position;
            camera.transform.rotation = Custom3.rotation;
            Custom3.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.Custom4)
        {
            camera.transform.position = Custom4.position;
            camera.transform.rotation = Custom4.rotation;
            Custom4.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else if (angle == CameraAngle.Custom5)
        {
            camera.transform.position = Custom5.position;
            camera.transform.rotation = Custom5.rotation;
            Custom5.GetComponent<CameraAngles>().StartMovingCamera(camera, camMove);
        }
        else
        {
            Debug.LogWarning("the camera angle for this line (" + spokenLine.ID + ") makes no sense.");
        }
        
    }
}