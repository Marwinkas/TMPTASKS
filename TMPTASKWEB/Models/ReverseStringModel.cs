namespace TMPTASKWEB.Models
{
    public class ReverseStringModel
    {
        /// <summary>
        /// ����������� �����
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// ����������� �����
        /// </summary>
        public string? Reverse { get; set; }
        /// <summary>
        /// ������� ��� ���������� ������ ������ � ������������ ������
        /// </summary>
        public string[]? OutputSymbol { get; set; }
        /// <summary>
        /// ���������� ���������, ������� ���������� � ������������� �� ������� �����
        /// </summary>
        public string? OutputVowelSubstring { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public string? Sort { get; set; }
        /// <summary>
        /// ������� ��������� ������
        /// </summary>
        public string[]? RemoveStroke { get; set; }
    }

}