using BepInEx;
using System;
using UnityEngine;

namespace SexTemp
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        /*  
            UI TEMP BY SERENITY
 
            AM I THE SIGMA 

            GIVE CREDITS NIGGER
        */

        // Bools
        bool show = false;
        bool toggle = false;

        // Floats
        float amount = 1f;

        // Font
        Font font = null;

        void Start()
        {
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }


        // UI Sex
        void OnGUI()
        {
            if (show)
            {
                GUI.color = Color.Lerp(new Color32(215, 140, 190, 255), Color.black, Mathf.PingPong(Time.time, 1f));

                GUI.Box(new Rect(5, 5, 150, 300), "SERENITY TEMP");

                GUILayout.BeginArea(new Rect(5, 30, 150, 300));

                if (GUILayout.Button($"Button: {toggle.ToString()}"))
                {
                    toggle = !toggle;
                }

                GUILayout.Space(5);

                DrawSlider("Amount", ref amount, 1f, 3f);

                GUILayout.EndArea();
            }
        }

        // Helper function for slider with a clean label
        static void DrawSlider(string name,ref float value, float min, float max)
        {
            GUILayout.Label($"{name}: {value.ToString("F2")}");

            value = GUILayout.HorizontalSlider(value, min, max);
        }

        void Update()
        {
            // set font to Candara size 14
            if (font == null)
            {
                font = Font.CreateDynamicFontFromOSFont("Candara", 14);
            }

            // Show and Hide UI with enter Key
            if (UnityEngine.InputSystem.Keyboard.current.enterKey.wasPressedThisFrame)
            {
                show = !show;
            }
        }
    }
}
