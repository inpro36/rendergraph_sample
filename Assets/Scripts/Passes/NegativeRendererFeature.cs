using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NegativeRendererFeature : ScriptableRendererFeature
    {
        private NegativeRenderPass _pass;
    
        public override void Create()
        {
            _pass = new NegativeRenderPass
            {
                renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing
            };
        }
    
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(_pass);
        }
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // ここでPassの破棄処理を呼び出す
                _pass.Cleanup();
            }
        }
    }