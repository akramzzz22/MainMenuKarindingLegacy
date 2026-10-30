using UnityEngine;
using UnityEngine.UI;

namespace KarindingLegacy.UI
{
    /// <summary>
    /// Menempelkan teks UI ke kunci lokalisasi. Teks otomatis diperbarui saat bahasa diganti.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private string key;

        private Text label;

        public string Key => key;

        private void Awake()
        {
            label = GetComponent<Text>();
        }

        private void OnEnable()
        {
            LocalizationManager.LanguageChanged += Apply;
            Apply();
        }

        private void OnDisable()
        {
            LocalizationManager.LanguageChanged -= Apply;
        }

        public void SetKey(string newKey)
        {
            key = newKey;
            if (label == null) label = GetComponent<Text>();
            Apply();
        }

        public void Apply()
        {
            if (label == null) label = GetComponent<Text>();
            if (label == null || string.IsNullOrEmpty(key)) return;

            label.text = LocalizationManager.Get(key);
        }
    }
}
