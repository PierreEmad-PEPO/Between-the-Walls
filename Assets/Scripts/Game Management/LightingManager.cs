using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private float time = 1;
    private List<Light> directionalLights = new List<Light>();
    private List<Light> pointLights = new List<Light>();
    private List<Light> spotLights = new List<Light>();
    private Dictionary<Light, float> defaultIntensity = 
        new Dictionary<Light, float>();

    public static LightingManager Instance { get; private set; }

    private void Start() =>FindAllLights();

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
            TurnOffLights(LightType.Point);
        
        if (Input.GetKeyUp(KeyCode.LeftShift))     
            TurnOnLights(LightType.Point);      
    }

    private void FindAllLights()
    {
        Light[] allLights = FindObjectsByType<Light>(FindObjectsSortMode.None);

        directionalLights = allLights.Where(l => l.type == LightType.Directional).ToList();
        pointLights = allLights.Where(l => l.type == LightType.Point).ToList();
        spotLights = allLights.Where(l => l.type == LightType.Spot).ToList();
        foreach (Light light in allLights)
        {
            defaultIntensity.Add(light, light.intensity);
        }
    }

    private IEnumerator ChangeIntensity(List<Light> lights, float target)
    {
        foreach (Light light in lights)
        {
            StartCoroutine(ChangeIntensity(light, light.intensity, target));
        }
        yield return null;
    }

    private IEnumerator RestoreIntensity(List<Light> lights)
    {
        foreach (Light light in lights)
        {
            StartCoroutine(ChangeIntensity(light, light.intensity, defaultIntensity[light]));
        }
        yield return null;
    }

    private IEnumerator ChangeIntensity(Light light, float from, float target)
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

    private void TurnOffLights(LightType type)
    {
        List<Light> lightsToAffect = directionalLights;
        switch (type)
        {
            case LightType.Directional:
                lightsToAffect = directionalLights;
                break;
            case LightType.Point:
                lightsToAffect = pointLights;
                break;
            case LightType.Spot:
                lightsToAffect = spotLights;
                break;
        }
        StartCoroutine(ChangeIntensity(lightsToAffect, 0));
    }

    private void TurnOnLights(LightType type)
    {
        List<Light> lightsToAffect = directionalLights;
        switch (type)
        {
            case LightType.Directional:
                lightsToAffect = directionalLights;
                break;
            case LightType.Point:
                lightsToAffect = pointLights;
                break;
            case LightType.Spot:
                lightsToAffect = spotLights;
                break;
        }
        StartCoroutine(RestoreIntensity(lightsToAffect));
    } 
}