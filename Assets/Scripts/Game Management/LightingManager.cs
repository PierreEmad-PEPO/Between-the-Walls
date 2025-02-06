using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private float minFlickerDelay = 0f;
    [SerializeField] private float maxFlickerDelay = 0.2f;
    [SerializeField] private SerializedDictionary<RoomNames, List<Light>>
        lightsDic = new SerializedDictionary<RoomNames, List<Light>>();

    private Dictionary<Light, float> defaultIntensity
        = new Dictionary<Light, float>();
    private Dictionary<Light, Color> defaultColor = new Dictionary<Light, Color>();
    private Dictionary<Light, bool> isFlickering = new Dictionary<Light, bool>();

    public static LightingManager Instance { get; private set; }

    private void Start()
    {
        GetAllLights();
        StartFlicker(RoomNames.Room1);
    }

    private void GetAllLights()
    {
        Light[] allLights = FindObjectsByType<Light>(FindObjectsSortMode.None);

        foreach (Light l in allLights)
        {
            defaultIntensity.Add(l, l.intensity);
            defaultColor.Add(l, l.color);
            isFlickering.Add(l, false);
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            TurnOffLights(RoomNames.Room1, 0f);
        
        if (Input.GetKeyUp(KeyCode.LeftShift))     
            TurnOnLights(RoomNames.Room1, 0.5f);      
    }

    private IEnumerator ChangeIntensity(List<Light> lights, float target, float time)
    {
        foreach (Light light in lights)
        {
            StartCoroutine(
                ChangeIntensity(light, light.intensity, target, time)
                );
        }
        yield return null;
    }

    private IEnumerator RestoreIntensity(List<Light> lights, float time)
    {
        foreach (Light light in lights)
        {
            StartCoroutine(
                ChangeIntensity(light, light.intensity,
                defaultIntensity[light], time)
                );
        }
        yield return null;
    }

    private IEnumerator ChangeIntensity(Light light, float from, float target, float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            light.intensity = Mathf.Lerp(from, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        light.intensity = target;
    }
    private IEnumerator Flicker(Light light)
    {
        while (isFlickering[light])
        {
            light.intensity = Random.Range(0f, 4f);
            yield return new 
                WaitForSeconds(Random.Range(minFlickerDelay, maxFlickerDelay));
        }
    }

    public void TurnOffLights(RoomNames roomName, float time)
    {
        List<Light> lightsToAffect = lightsDic[roomName];

        StopFlicker(roomName);
        StartCoroutine(ChangeIntensity(lightsToAffect, 0, time));
    }

    public void TurnOnLights(RoomNames roomName, float time)
    {
        List<Light> lightsToAffect = lightsDic[roomName];

        StartCoroutine(RestoreIntensity(lightsToAffect, time));
    }

    public void StartFlicker(RoomNames roomName)
    {
        foreach(Light l in lightsDic[roomName])
        {
            isFlickering[l] = true;
            StartCoroutine(Flicker(l));
        }
    }
    public void StopFlicker(RoomNames roomName)
    {
        foreach (Light l in lightsDic[roomName])
        {
            isFlickering[l] = false;
        }
    }
}