using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Material hpbarMaterial;

    [SerializeField] public Image hpbarImage;
    [SerializeField] public float AnimSpeed;

    private float NowValue;
    private float MaxValue;
    private float AnimatingValue;

    public void SetValue(float now, float max)
    {
        NowValue = now;
        MaxValue = max;
    }

    public void Init(float max)
    {
        hpbarMaterial = Instantiate(hpbarImage.material);
        hpbarImage.material = hpbarMaterial;
        AnimatingValue = max;
    }

    private void Update()
    {
        AnimatingValue += (NowValue - AnimatingValue) * (Time.deltaTime / AnimSpeed);
        hpbarMaterial.SetFloat("_Value", AnimatingValue / MaxValue);
    }
}
