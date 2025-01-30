using System;
using System.Reflection;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Coffee
{
    public class ReflectionTests
    {
        const BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;

        [Test]
        public void DoIntRangeProperty()
        {
            var method = typeof(MaterialEditor)
                    .GetMethod("DoIntRangeProperty", flags)
                    .CreateDelegate(typeof(Func<Rect, MaterialProperty, GUIContent, int>), null)
                as Func<Rect, MaterialProperty, GUIContent, int>;

            Assert.IsNotNull(method);
        }

        [Test]
        public void DoPowerRangeProperty()
        {
            var method = typeof(MaterialEditor)
                    .GetMethod("DoPowerRangeProperty", flags)
                    .CreateDelegate(typeof(Func<Rect, MaterialProperty, GUIContent, float, float>), null)
                as Func<Rect, MaterialProperty, GUIContent, float, float>;
            Assert.IsNotNull(method);
        }
    }
}
