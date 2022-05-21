
namespace WPF_резюме{

    /// <summary>
    /// список моих контактов
    /// </summary>
    internal class МоиКонтакты
    {
        /// <summary>
        /// моя телефон
        /// </summary>
        public string Телефон { get { return телефон; } set { телефон = value; } }
        private string телефон;

        /// <summary>
        /// моя почта
        /// </summary>
        public string Почта { get { return почта; } set { почта = value; } }
        private string почта;

        /// <summary>
        /// моя соцсеть
        /// </summary>
        public string СоцСеть { get { return соцсеть; } set { соцсеть = value; } }
        private string соцсеть;       
    }
}
