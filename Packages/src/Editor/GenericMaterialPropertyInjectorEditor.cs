using System.Linq;
using UnityEditor;

namespace Coffee.UIExtensions
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GenericMaterialPropertyInjector), true)]
    internal class GenericMaterialPropertyInjectorEditor : UIMaterialPropertyInjectorEditor
    {
        private SerializedProperty _accessor;

        protected override void OnEnable()
        {
            base.OnEnable();
            _accessor = serializedObject.FindProperty("m_Accessor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_accessor);
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
