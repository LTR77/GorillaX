﻿using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace Delta.Patches
{
    public class Menu : MonoBehaviour
    {
        public static bool IsPatched { get; private set; }

        internal static void ApplyHarmonyPatches()
        {
            if (!IsPatched)
            {
                if (instance == null)
                {
                    instance = new Harmony(Delta.PluginInfo.GUID);
                }
                instance.PatchAll(Assembly.GetExecutingAssembly());
                IsPatched = true;
            }
        }

        internal static void RemoveHarmonyPatches()
        {
            if (instance != null && IsPatched)
            {
                IsPatched = false;
            }
        }

        private static Harmony instance;
    }
}
