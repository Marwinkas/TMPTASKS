namespace TMPTASKWEB.Models
{
    public class ReverseStringModel
    {
        /// <summary>
        /// Изначальный текст
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// Реверсивный Текст
        /// </summary>
        public string? Reverse { get; set; }
        /// <summary>
        /// Сколько раз повторялся каждый символ в обработанной строке
        /// </summary>
        public string[]? OutputSymbol { get; set; }
        /// <summary>
        /// Наибольшая подстрока, которая начинается и заканчивается на гласную букву
        /// </summary>
        public string? OutputVowelSubstring { get; set; }
        /// <summary>
        /// Сортировка
        /// </summary>
        public string? Sort { get; set; }
        /// <summary>
        /// Удалить рандомный символ
        /// </summary>
        public string[]? RemoveStroke { get; set; }
    }

}