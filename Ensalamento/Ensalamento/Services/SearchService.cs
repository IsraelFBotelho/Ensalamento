using Ensalamento.Data;
using Ensalamento.DTOs;
using Ensalamento.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Primitives;
using System.Globalization;
using System.Threading;

namespace Ensalamento.Services
{
    public interface ISearchService
    {
        List<SearchResult> Find(string name);
    }

    public class SearchService : ISearchService
    {
        private readonly ESContext _context;

        public SearchService(ESContext context)
        {
            _context = context;
        }

        public List<SearchResult> Find(string name)
        {
            return (
                from cr in _context.ClassReservations
                join u in _context.Users on cr.RequesterId equals u.Registration
                join s in _context.Subjects on cr.SubjectId equals s.Id
                where u.FirstName.Contains(name) || u.LastName.Contains(name)
                select new SearchResult
                {
                    SubjectId = cr.SubjectId,
                    SubjectName = s.Name,
                    TeacherName = u.FirstName + " " + u.LastName,
                    Date = GetDateAsString(cr.StartDate),
                    ClassId = cr.ClassId,
                    EventName = cr.EventName
                }).ToList();
        }

        private static string GetDateAsString(DateTime date)
        {
            var culture = new CultureInfo("pt-BR");
            string dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            string hour = date.ToShortTimeString();
            string shortDate = " (" + date.Day + "/" + date.Month + ")";

            return char.ToUpper(dayOfWeek[0]) + dayOfWeek[1..] + shortDate + " - " + hour;
        }
    }
}
