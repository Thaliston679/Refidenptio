using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeSettings : MonoBehaviour
{
    public Volume globalVolume;
    ChromaticAberration chromaticAberration;
    Bloom bloom;
    MotionBlur motionBlur;
    Vignette vignette;

    private void Start()
    {
        globalVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        globalVolume.profile.TryGet<Bloom>(out bloom);
        globalVolume.profile.TryGet<MotionBlur>(out motionBlur);
        globalVolume.profile.TryGet<Vignette>(out vignette);
    }

    public void ChangeChromaticAberration(bool value)
    {
        chromaticAberration.active = value;
    }

    public void ChangeBloom(bool value)
    {
        bloom.active = value;
    }

    public void ChangeMotionBlur(bool value)
    {
        motionBlur.active = value;
    }

    public void ChangeVignette(bool value)
    {
        vignette.active = value;
    }
}
