using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface ILoggerRepository
    {

        public void Info(string message);
        public void Info(string message, Exception ex);

        public void Warning(string message);
        public void Warning(string message, Exception ex);

        public void Fatal(string message);
        public void Fatal(string message, Exception ex);

    }
}
