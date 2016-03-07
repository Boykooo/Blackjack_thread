using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    [Serializable]
    public class DataLoadException : ApplicationException
    {
        public DataLoadException() : base("Ошибка загрузки данных")
        {

        }
        public DataLoadException(string message) : base(message) { }
        public DataLoadException(string message, Exception inner) : base(message, inner) { }
        protected DataLoadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
