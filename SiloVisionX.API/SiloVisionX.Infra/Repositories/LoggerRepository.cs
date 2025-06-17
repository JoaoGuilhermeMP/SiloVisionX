using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {

        private readonly LogDataContext _context;

        public LoggerRepository(LogDataContext context)
        {
            _context = context;
        }

        void ILoggerRepository.Fatal(string message)
        {
            var data = new Log
            {
                Type = "Fatal",
                Date = DateTime.Now,
                Message = message,
            };

            _context.Logs.Add(data);
            _context.SaveChanges();

        }

        void ILoggerRepository.Fatal(string message, Exception ex)
        {
            var data = new Log
            {
                Type = "Fatal",
                Date = DateTime.Now,
                Message = message + ex.ToString(),
            };

            _context.Logs.Add(data);
            _context.SaveChanges();
        }

        void ILoggerRepository.Info(string message)
        {
            var data = new Log
            {
                Type = "Info",
                Date = DateTime.Now,
                Message = message,
            };

            _context.Logs.Add(data);
            _context.SaveChanges();
        }

        void ILoggerRepository.Info(string message, Exception ex)
        {
            var data = new Log
            {
                Type = "Info",
                Date = DateTime.Now,
                Message = message + ex.ToString(),
            };

            _context.Logs.Add(data);
            _context.SaveChanges();
        }

        void ILoggerRepository.Warning(string message)
        {
            var data = new Log
            {
                Type = "Warning",
                Date = DateTime.Now,
                Message = message,
            };

            _context.Logs.Add(data);
            _context.SaveChanges();
        }

        void ILoggerRepository.Warning(string message, Exception ex)
        {
            var data = new Log
            {
                Type = "Fatal",
                Date = DateTime.Now,
                Message = message + ex.ToString(),
            };

            _context.Logs.Add(data);
            _context.SaveChanges();
        }
    }
}
