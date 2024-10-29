using System;

namespace UnityEngine.Rendering.Universal
{
    [Serializable, VolumeComponentMenu("Post-processing/Negative")]
    [SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
    public sealed class NegativeVolume : VolumeComponent, IPostProcessComponent
    {
        public ClampedFloatParameter _Intensity = new (0f, 0f, 1.0f);

        /// <inheritdoc/>
        public bool IsActive() => _Intensity.value > 0f;

        /// <inheritdoc/>
        [Obsolete("Unused #from(2023.1)", false)]
        public bool IsTileCompatible() => false;
    }
}
