using DG.Tweening;
using UnityEngine;
using UnityEngine.VFX;

public class EnergyOrb : MonoBehaviour
{
    [SerializeField]
    private VisualEffect _energyOrb;

    /// <summary>
    /// x est égal à l'intensité la plus haute et y la plus basse
    /// </summary>
    [SerializeField]
    private Vector2 _energyColorIntensity;

    /// <summary>
    /// x est égal à la première durée et y à la deuxième
    /// </summary>
    [SerializeField]
    private Vector2 _duration;

    private float _durationTime;

    private float _actualIntensity;

    private float _actualDuration;

    private float _lastIntensity;

    private Color _actualColor;

    private int _actualPoint;

    private Gradient updatedGradient = new Gradient();

    private void Start()
    {
        _actualPoint = 1;
        _actualColor = _energyOrb.GetGradient("OrbColor").colorKeys[0].color;
    }

    private void Update()
    {
        _durationTime += Time.deltaTime;
        if (_durationTime >= _actualDuration)
        {
            _durationTime = 0;
            FindNewPoint();
        }

        Gradient gradient = _energyOrb.GetGradient("OrbColor");
        GradientColorKey[] colorKeys = gradient.colorKeys;
        GradientColorKey[] newColorKeys = new GradientColorKey[colorKeys.Length];

        newColorKeys[0] = SetColor(_actualColor, colorKeys[0].time);
        updatedGradient.SetKeys(newColorKeys, gradient.alphaKeys);
        _energyOrb.SetGradient("OrbColor", updatedGradient);
    }

    private void Orb()
    {
        Gradient gradient = _energyOrb.GetGradient("OrbColor");
        float duration = _duration.x;
        float intensity = _energyColorIntensity.x;
        if (_actualPoint == 2)
        {
            duration = _duration.y;
            intensity = _energyColorIntensity.y;
            _actualPoint = 1;
        }
        else
        {
            _actualPoint = 2;
        }
        /* Debug.Log("orb");
         

         _actualColor = _energyOrb.GetGradient("OrbColor").colorKeys[0].color;
         DOVirtual.Color(_actualColor, _actualColor * intensity * 10, duration, (value) =>
         {
             _energyOrb.GetGradient("OrbColor").colorKeys[0].color = value;
         });*/

        GradientColorKey[] colorKeys = gradient.colorKeys;
        GradientColorKey[] newColorKeys = new GradientColorKey[colorKeys.Length];
        Debug.Log(colorKeys.Length);

        // Appliquer le changement sur toutes les couleurs du gradient
        for (int i = 0; i < colorKeys.Length; i++)
        {
            Color originalColor = colorKeys[i].color;
            Debug.Log("Intensity added& : " + originalColor * intensity);
            Debug.Log("Intensity removed& : " + originalColor);
            DOVirtual.Color(originalColor, originalColor * intensity, duration, (value) =>
            {
                newColorKeys[i] = new GradientColorKey(value, colorKeys[i].time);
                // Créer un nouveau gradient à chaque mise à jour
                Gradient updatedGradient = new Gradient();
                updatedGradient.SetKeys(newColorKeys, gradient.alphaKeys);
                _energyOrb.SetGradient("OrbColor", updatedGradient);
            });
        }

        Invoke("Orb", duration);
    }

    private void FindNewPoint()
    {
        if (_actualPoint == 2)
        {
            _actualDuration = _duration.y;
            _actualIntensity = _energyColorIntensity.y;
            _lastIntensity = _energyColorIntensity.x;
            _actualPoint = 1;
        }
        else
        {
            _actualDuration = _duration.x;
            _actualIntensity = _energyColorIntensity.x;
            _lastIntensity = _energyColorIntensity.y;
            _actualPoint = 2;
        }
    }

    private GradientColorKey SetColor(Color colorToSet, float time)
    {
        Color gradientColor;
        if (_lastIntensity < _actualIntensity)
        {
            gradientColor = colorToSet * _actualIntensity * (_durationTime / _actualDuration);
        }
        else
        {
            gradientColor = colorToSet * _actualIntensity * (1 - (_durationTime / _actualDuration));
        }

        return new GradientColorKey(gradientColor, time);
    }
}
