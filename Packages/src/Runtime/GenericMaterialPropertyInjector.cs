using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

namespace Coffee.UIExtensions
{
    [ExecuteAlways]
    [Icon("Packages/com.coffee.ui-material-property-injector/Icons/UIMaterialPropertyInjectorIcon.png")]
    public class GenericMaterialPropertyInjector : UIMaterialPropertyInjector
    {
        [SerializeField]
        private Component m_Target;

        [SerializeField]
        private Material m_BaseMaterial;

        private Func<Material> _getter = null;
        private Action<Material> _setter = null;

        public override Material material => _material;

        public override Material defaultMaterialForRendering => m_BaseMaterial
            ? m_BaseMaterial
            : m_BaseMaterial = getter?.Invoke();

        private Func<Material> getter
        {
            get
            {
                InitializeIfNeeded();
                return _getter;
            }
        }

        private Action<Material> setter
        {
            get
            {
                InitializeIfNeeded();
                return _setter;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            RestoreMaterial();
            InjectIfNeeded();


            EditorSceneManager.sceneSaving += OnSceneSaving;
            EditorSceneManager.sceneSaved += OnSceneSaved;
        }

        private void OnSceneSaved(Scene scene)
        {
        }

        private void OnSceneSaving(Scene scene, string path)
        {
            RestoreMaterial();
        }

        protected override void OnDisable()
        {
            RestoreMaterial();
            _getter = null;
            _setter = null;

            base.OnDisable();

            EditorSceneManager.sceneSaving -= OnSceneSaving;
            EditorSceneManager.sceneSaved -= OnSceneSaved;
        }

        private void InitializeIfNeeded()
        {
            if (m_Target && m_Target.gameObject != gameObject)
            {
                m_Target = GetComponent(m_Target.GetType());
                m_BaseMaterial = null;
                _getter = null;
                _setter = null;
            }

            if (m_Target && _getter == null && _setter == null)
            {
                // Initialize getter and setter if not already done.
                var pi = m_Target.GetType().GetProperty("material");
                _getter = pi.GetGetMethod().CreateDelegate(typeof(Func<Material>), m_Target) as Func<Material>;
                _setter = pi.GetSetMethod().CreateDelegate(typeof(Action<Material>), m_Target) as Action<Material>;
            }
        }

        private void RestoreMaterial()
        {
            if (m_BaseMaterial && m_Target && m_Target.gameObject == gameObject)
            {
                setter?.Invoke(m_BaseMaterial);
            }

            m_BaseMaterial = null;
        }

        protected override void InjectIfNeeded()
        {
            // Base material has been changed.
            Profiler.BeginSample("(MPI)[Injector] InjectIfNeeded > Check the base material has been changed");
            var currentMaterial = getter?.Invoke();
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
            setter?.Invoke(_material);
            Profiler.EndSample();
        }
    }
}
