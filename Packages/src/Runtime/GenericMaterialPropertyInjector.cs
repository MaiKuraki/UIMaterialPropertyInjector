using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace Coffee.UIExtensions
{
    [ExecuteAlways]
    [Icon("Packages/com.coffee.ui-material-property-injector/Icons/UIMaterialPropertyInjectorIcon.png")]
    public class GenericMaterialPropertyInjector : UIMaterialPropertyInjector
    {
        [SerializeField]
        private MaterialAccessor m_Accessor = new MaterialAccessor();

        [SerializeField]
        private Material m_BaseMaterial;

        public override Material material => _material;

        public override Material defaultMaterialForRendering => m_BaseMaterial
            ? m_BaseMaterial
            : m_Accessor.InitializeIfNeeded(gameObject)
                ? m_BaseMaterial = m_Accessor.Get()
                : null;

        protected override void OnEnable()
        {
            base.OnEnable();
            RestoreMaterial();
            InjectIfNeeded();

#if UNITY_EDITOR
            EditorSceneManager.sceneSaving += OnSceneSaving;
#endif
        }

        protected override void OnDisable()
        {
            RestoreMaterial();
            base.OnDisable();

#if UNITY_EDITOR
            EditorSceneManager.sceneSaving -= OnSceneSaving;
#endif
        }

#if UNITY_EDITOR
        private void OnSceneSaving(Scene scene, string path)
        {
            RestoreMaterial();
        }
#endif

        internal void RestoreMaterial()
        {
            if (m_BaseMaterial && m_Accessor.InitializeIfNeeded(gameObject))
            {
                m_Accessor.Set(m_BaseMaterial);
            }

            m_BaseMaterial = null;
        }

        protected override void InjectIfNeeded()
        {
            if (!m_Accessor.InitializeIfNeeded(gameObject)) return;

            // Base material has been changed.
            Profiler.BeginSample("(MPI)[Injector] InjectIfNeeded > Check the base material has been changed");
            var currentMaterial = m_Accessor.Get();
            if (_material != currentMaterial)
            {
                m_BaseMaterial = currentMaterial;
                _material = GetModifiedMaterial(m_BaseMaterial);
                _dirty = true;
            }

            Profiler.EndSample();

            // Skip if not dirty.
            if (!_dirty || !canInject || !_material) return;
            _dirty = false;

            // Inject properties to materials.
            Profiler.BeginSample("(MPI)[Injector] InjectIfNeeded > Inject properties to materials");
            s_Materials.Clear();
            s_Materials.Add(_material);
            for (var i = 0; i < properties.Count; i++)
            {
                properties[i].Inject(s_Materials);
            }

            s_Materials.Clear();
            m_Accessor.Set(_material);
            Profiler.EndSample();
        }
    }
}
