using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public static ParticleSystemManager Instance;

    [System.Serializable]
    public class ParticleEffect
    {
        public string name; // Tên hiệu ứng
        public ParticleSystem particleSystem; // Tham chiếu tới ParticleSystem
        public bool isPersistent;
    }

    public List<ParticleEffect> particleEffects = new List<ParticleEffect>(); // Danh sách các hiệu ứng

    private Dictionary<string, ParticleSystem> particleEffectDictionary;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Khởi tạo Dictionary và thêm các hiệu ứng
        particleEffectDictionary = new Dictionary<string, ParticleSystem>();
        foreach (var effect in particleEffects)
        {
            if (!particleEffectDictionary.ContainsKey(effect.name))
            {
                particleEffectDictionary.Add(effect.name, effect.particleSystem);
            }
        }
    }

    /// <summary>
    /// Bật một hiệu ứng hạt tại vị trí cụ thể.
    /// </summary>
    /// <param name="effectName">Tên hiệu ứng cần bật</param>
    /// <param name="position">Vị trí để hiển thị hiệu ứng</param>
   public void PlayParticleEffect(string effectName, Vector3 position, float delayTime = 0f)
    {
        if (particleEffectDictionary.TryGetValue(effectName, out ParticleSystem particlePrefab))
        {
            ParticleSystem newParticle = Instantiate(particlePrefab, position, Quaternion.identity);

            // Chạy hệ thống hạt
            newParticle.Play();

            // Nếu hiệu ứng không phải là xuyên suốt, hủy sau thời gian delay
            ParticleEffect effect = particleEffects.Find(effectsInList => effectsInList.particleSystem == particlePrefab);
            if (effect != null && !effect.isPersistent)
            {
                StartCoroutine(DestroyParticleAfterDelay(newParticle.gameObject, delayTime));
            }
        }
        else
        {
            Debug.LogWarning($"Particle Effect '{effectName}' not found!");
        }
    }



    /// <summary>
    /// Tắt một hiệu ứng hạt.
    /// </summary>
    /// <param name="effectName">Tên hiệu ứng cần tắt</param>
    public void StopParticleEffect(string effectName)
    {
        if (particleEffectDictionary.TryGetValue(effectName, out ParticleSystem particleSystem))
        {
            particleSystem.Stop(); // Dừng hiệu ứng
        }
        else
        {
            Debug.LogWarning($"Particle Effect '{effectName}' not found!");
        }
    }
    IEnumerator DestroyParticleAfterDelay(GameObject particle, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        // Xóa particle sau thời gian trễ
        Destroy(particle);
    }

}
