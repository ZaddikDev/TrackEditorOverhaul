using HarmonyLib;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ZadDev.TrackEditorOverhaul.Patches
{
    [HarmonyPatch(typeof(CRTrackEditor))]
    internal class BPMTextInputPatch
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        static void AwakePatch(CRTrackEditor __instance, ref GameObject[] ___ShowSettingBPMFirstBeat)
        {
            GameObject mouseSenseSlider = ___ShowSettingBPMFirstBeat[0].transform.Find("HELP MENU/Controls/Mouse Sense Slider").gameObject;

            Slider s = mouseSenseSlider.GetComponent<Slider>();

            GameObject txtObj = mouseSenseSlider.transform.Find("Fill Area/RESULT").gameObject;

            InputField ifield = (InputField)txtObj.AddComponent(typeof(InputField));
            Text text = txtObj.GetComponent<Text>();

            ifield.text = s.value.ToString();
            ifield.textComponent = text;
            ifield.characterLimit = 5;
            ifield.characterValidation = InputField.CharacterValidation.Integer;
            ifield.onValidateInput += ValidateInput;

            // Remove text modify listener, change it to our listener (to change inputfield value instead of the underlying text component)
            s.onValueChanged.RemoveAllListeners();
            s.onValueChanged.AddListener(delegate { ifield.text = s.value.ToString(); });
            ifield.onEndEdit.AddListener(delegate { if (float.TryParse(ifield.text, out float val)) s.value = val; });

            TrackEditorOvBase.Instance.mlogger.LogInfo("Added text input to BPM slider");
        }

        private static char ValidateInput(string text, int charIndex, char addedChar)
        {
            if(float.TryParse(text + addedChar, out float _)) return addedChar;
            return '\0';
        }

        /*static private void LogGameObject(GameObject obj, string tree)
        {
            TrackEditorOvBase.Instance.mlogger.LogInfo("Instance GameObject name: " + tree + "/" + obj.name);
            foreach(Component c in obj.GetComponents<Component>()) 
            {
                TrackEditorOvBase.Instance.mlogger.LogInfo("Instance component type: " + c.GetType());
            }
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                LogGameObject(obj.transform.GetChild(i).gameObject, tree + "/" + obj.name);
            }
        }*/
    }
}
