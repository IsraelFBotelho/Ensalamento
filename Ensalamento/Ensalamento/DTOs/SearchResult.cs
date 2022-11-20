using System;

namespace Ensalamento.DTOs
{
    public class SearchResult
    {
        public string SubjectId { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public DateTime Date { get; set; }
        public string ClassId { get; set; } = null!;
        public string EventName { get; set; } = "Prova";
    }
}
