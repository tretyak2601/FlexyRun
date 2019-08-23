using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RageMode : MonoBehaviour
{
    [SerializeField] FlexyPlayer flex;
    [SerializeField] Slider rageSlider;

    public static RageMode Instance;

    public bool IsRageMode { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);

        flex.OnBarrierPassed += RageHandler;
    }

    private void RageHandler()
    {
        if (!IsRageMode)
            rageSlider.value += 50;

        if (rageSlider.value == rageSlider.maxValue)
        {
            StartCoroutine(EndAnimation(10));
            IsRageMode = true;
        }
    }

    IEnumerator EndAnimation(float time)
    {
        for (int i = 0; i < time / 0.02f; i++)
        {
            rageSlider.value -= rageSlider.maxValue / (time / 0.02f);
            yield return new WaitForSeconds(0.01f);
        }

        IsRageMode = false;
    }

    public void Restart()
    {
        IsRageMode = false;
        rageSlider.value = 0;
    }
}
