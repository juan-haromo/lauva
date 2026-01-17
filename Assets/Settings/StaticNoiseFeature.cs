using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StaticNoiseFeature : ScriptableRendererFeature {
    class StaticNoisePass : ScriptableRenderPass {
        public Material material;

        public override void 
            Execute(ScriptableRenderContext context, ref RenderingData renderingData) {
            if (material == null) return;
            CommandBuffer cmd = CommandBufferPool.Get("StaticNoisePass");
            RenderTargetIdentifier source = renderingData.cameraData.renderer.cameraColorTargetHandle;
            cmd.Blit(source, source, material);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    StaticNoisePass pass;
    public Material material;

    public override void Create() {
        pass = new StaticNoisePass { material = material };
        pass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) {
        renderer.EnqueuePass(pass);
    }
}