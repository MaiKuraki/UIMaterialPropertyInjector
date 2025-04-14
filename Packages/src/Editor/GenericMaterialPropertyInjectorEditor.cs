using UnityEditor;

namespace Coffee.UIExtensions
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GenericMaterialPropertyInjector), true)]
    internal class GenericMaterialPropertyInjectorEditor : UIMaterialPropertyInjectorEditor
    {
        private SerializedProperty _taregt;

        protected override void OnEnable()
        {
            base.OnEnable();
            _taregt = serializedObject.FindProperty("m_Target");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_taregt);
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
